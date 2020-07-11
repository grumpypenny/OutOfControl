using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealerSorcerer : PlayableCharacter
{
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
            // Enemy.TakeHit(offence * baseOffence)
        }
    }
}
