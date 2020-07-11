using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public PlayableCharacter GetLowestHealthPlayer()
    {
        PlayableCharacter lowestHP = null;
        foreach(PlayableCharacter player in gm.playableCharacters)
        {
            if (!player.dead)
            {
                if (lowestHP == null)
                {
                    lowestHP = player;
                } else if (lowestHP.health > player.health)
                {
                    lowestHP = player;
                }
            }
        }

        return lowestHP;
    }

    public PlayableCharacter GetRandomPlayer()
    {
        List<PlayableCharacter> livingPlayers = new List<PlayableCharacter>();
        foreach (PlayableCharacter player in gm.playableCharacters)
        {
            if (!player.dead)
            {
                livingPlayers.Add(player);
            }
        }

        int index = Random.Range(0, livingPlayers.Count);
        return livingPlayers[index];
    }

    public EnemyCharacter GetRandomEnemy()
    {
        List<EnemyCharacter> livingEnemies = new List<EnemyCharacter>();
        foreach (EnemyCharacter enemy in gm.enemies)
        {
            if (!enemy.dead)
            {
                livingEnemies.Add(enemy);
            }
        }

        int index = Random.Range(0, livingEnemies.Count);
        return livingEnemies[index];
    }
}
