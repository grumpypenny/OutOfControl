using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyCharacter[] enemies;
    public float enemyAttackAnimTime = 1f;

    PlayableCharacter PickRandomPlayable(PlayableCharacter[] playableCharacters)
    {
        int weightDenom = 0;
        for (int i = 1; i < playableCharacters.Length+1; i++)
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

        return playableCharacters[index];
    }

    public IEnumerator StartEnemyTurn(PlayableCharacter[] playableCharacters, TurnSystem ts)
    {
        foreach (EnemyCharacter enemy in enemies)
        {
            enemy.Attack(PickRandomPlayable(playableCharacters));
            yield return new WaitForSeconds(enemyAttackAnimTime);
        }

        if (ts != null)
        {
            ts.SetEnemyAction();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
