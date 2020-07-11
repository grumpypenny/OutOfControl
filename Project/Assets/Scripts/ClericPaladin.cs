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
