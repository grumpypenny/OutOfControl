using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSorcerer : PlayableCharacter
{
    /// <summary>
    /// The amount this unit heals when this unit is a support
    /// </summary>
    public float healAmount;
    public override void Start()
    {
        base.Start();
    }

    protected override void ActionCard()
    {
        if (isSupport)
        {
            PlayableCharacter target = pm.GetLowestHealthPlayer();

            if (target != null)
            {
                target.Heal(healAmount);
            }
        }
        else
        {
			EnemyCharacter enemy = pm.GetRandomEnemy();

			if (enemy != null)
			{
				enemy.TakeHit(offence * baseOffence);
			}
		}
    }
}
