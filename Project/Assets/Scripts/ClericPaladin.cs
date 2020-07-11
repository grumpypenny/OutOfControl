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
            pm.GetRandomPlayer().SetOffence(GetOffence() + clericOffenceBuff);
        }
        else
        {
            pm.GetRandomEnemy().TakeHit(offence * baseOffence);
        }
    }
}
