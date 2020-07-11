using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClericPaladin : PlayableCharacter
{
    public float clericOffenceBuff;
    public override void Start()
    {
        base.Start();
    }

    // TODO: Do this on a random ally
    protected override void ActionCard()
    {

        if (isSupport)
        {
            SetOffence(GetOffence() + clericOffenceBuff);
        }
        else
        {
            // Enemy.TakeHit(offence * baseOffence * positionMultiplier[position])
        }
    }
}
