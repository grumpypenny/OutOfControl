using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClericPaladin : PlayableCharacter
{
    /// <summary>
    /// The amount of offence this unit buffs when this unit is a support
    /// </summary>
    public float clericOffenceBuff;
    public override void Start()
    {
        base.Start();
    }

    protected override void ActionCard()
    {

		if (isSupport)
		{
			PlayableCharacter target = pm.GetRandomPlayer();

			if (target != null)
			{
				target.SetOffence(GetOffence() + clericOffenceBuff);
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
