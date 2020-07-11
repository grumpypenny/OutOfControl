using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidRanger : PlayableCharacter
{
    /// <summary>
    /// The amount of defence this unit buffs when this unit is a support
    /// </summary>
    public float druidDefenceBuff;

    public override void Start()
    {
        base.Start();
    }

    // TODO: Do this on a random ally
    protected override void ActionCard()
    {
        //float effectMultiplier = positionMultiplier[position];
        //if (effectMultiplier == 0.75f)
        //{
        //    effectMultiplier = 1f;
        //}
        if (isSupport)
        {
            SetDefence(GetDefence() + druidDefenceBuff);
        } else
        {
            // Enemy.TakeHit(offence * baseOffence * effectMultiplier)
        }
    }
}
