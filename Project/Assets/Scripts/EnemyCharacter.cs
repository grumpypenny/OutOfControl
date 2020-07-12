using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Character Attacks playable characters
/// </summary>
public class EnemyCharacter : Character
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(PlayableCharacter pc)
    {
		if (pc == null)
		{
			return;
		}

		if (dead)
		{
			return;
		}

		anim.SetTrigger("Attack");
        pc.TakeHit(offence * baseOffence);
    }
}
