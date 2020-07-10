using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for damageable game objects
public interface ICharacter<T>
{
    void TakeHit(T damage);
    void Heal(T health);
    void SetOffence(T offence);
    void SetDefence(T defence);
}
