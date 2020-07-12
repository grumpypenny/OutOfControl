using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    /// <summary>
    /// Time for enemy attack anim
    /// </summary>
    public float enemyAttackAnimTime = 1f;

    /// <summary>
    /// Enemy chooses random player with higher chance of picking frontline
    /// </summary>
    /// <param name="playableCharacters"></param>
    /// <returns></returns>
    PlayableCharacter PickRandomPlayable(PlayableCharacter[] playableCharacters)
    {
        List<PlayableCharacter> livingPlayers = new List<PlayableCharacter>();
        foreach (PlayableCharacter player in playableCharacters)
        {
            if (!player.dead)
            {
                livingPlayers.Add(player);
            }
        }

        int weightDenom = 0;
        for (int i = 1; i < livingPlayers.Count+1; i++)
        {
            weightDenom += i;
        }
        
        int rando = Random.Range(0, weightDenom);
        int index = 0;
        int count = 0;
        int interval = 2;
        while (count < rando)
        {
            count += interval;
            interval++;
            index++;
        }

        return livingPlayers[index];
    }

    public IEnumerator StartEnemyTurn(EnemyCharacter[] enemies, PlayableCharacter[] playableCharacters, TurnSystem ts)
    {
        bool isTaunt = false;
        PlayableCharacter tauntPlayer = null;

        foreach (PlayableCharacter player in playableCharacters)
        {
            if (player.isTaunting)
            {
                tauntPlayer = player;
                isTaunt = true;
            }
        }

        foreach (EnemyCharacter enemy in enemies)
        {
            if (isTaunt)
            {
                enemy.Attack(tauntPlayer);
            } else
            {
                enemy.Attack(PickRandomPlayable(playableCharacters));
                yield return new WaitForSeconds(enemyAttackAnimTime);
            }
        }

        if (ts != null)
        {
            ts.SetEnemyAction();
        }
    }
}
