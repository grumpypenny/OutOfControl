using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for damageable game objects
public interface IDamageable<T>
{
    void TakeHit(T damage);
}
