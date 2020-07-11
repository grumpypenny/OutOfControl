using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyCharacter[] enemies;
    public float enemyAttackAnimTime = 1f;

    public void StartEnemyTurn(PlayableCharacter[] playableCharacters, TurnSystem ts)
    {
        foreach (EnemyCharacter enemy in enemies)
        {
            enemy.Attack(PickRandomPlayable(playableCharacters));
            StartCoroutine(EnemyAttack());
        }

        if (ts != null)
        {
            ts.SetEnemyAction();
        }
    }

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

    private IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(enemyAttackAnimTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
