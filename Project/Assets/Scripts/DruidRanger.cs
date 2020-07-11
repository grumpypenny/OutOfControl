using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DruidRanger : PlayableCharacter
{
    public float druidDefenceBuff;

    public override void Start()
    {
        base.Start();
    }

    // TODO: Do this on a random ally
    protected override void ActionCard()
    {
        if (isSupport)
        {
            SetDefence(GetDefence() + druidDefenceBuff);
        } else
        {
            // Enemy.TakeHit(offence * baseOffence)
        }
    }
}
