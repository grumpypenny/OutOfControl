using UnityEngine;

// Interface for damageable game objects
public interface ICharacter<T>
{
    void TakeHit(T damage);
    void Heal(T health);
    void SetOffence(T offence);
    T GetOffence();
    void SetDefence(T defence);
    T GetDefence();
    void onTurnEnd();
}
