using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSorcerer : PlayableCharacter
{
    /// <summary>
    /// The amount this unit heals when this unit is a support
    /// </summary>
    public float heal;
    public override void Start()
    {
        base.Start();
    }

    // TODO: Do this on a random ally
    protected override void ActionCard()
    {
        if (isSupport)
        {
            Heal(heal);
        }
        else
        {
            // Enemy.TakeHit(offence * baseOffence * positionMultiplier[position])
        }
    }
}
