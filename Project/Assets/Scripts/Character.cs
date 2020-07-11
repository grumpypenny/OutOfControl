using System.Collections;
using UnityEngine;

// This class is for any game object that needs stats such as health, defence, and offence
/* NOTES:
 * base defence and base offence are between 0 and 1
 * to buff defence or offence stat, increase the defence or offence variable and vice versa
 */

public class Character : MonoBehaviour, ICharacter<float>
{
    [Header("Base stats")]
    public float startHealth;
    public float health;

    public float startBaseDefence;
    protected float baseDefence;

    public float startBaseOffence;
    protected float baseOffence;

    [Space]

    [Header("Base stat multipliers")]
    public float startDefence;
    protected float defence;

    public float startOffence;
    protected float offence;

    [Space]

    [Header("Character states")]
    //public int position;
    public bool dead;
    public bool isTaunting;

    // Start is called before the first frame update
    public virtual void Start()
    {
        health = startHealth;

        baseDefence = startBaseDefence;
        baseOffence = startBaseOffence;

        defence = startDefence;
        offence = startOffence;

        dead = false;
        isTaunting = false;
    }

    /// <summary>
    /// This character loses health equal to damage. Falling to zero or less health causes character death.
    /// </summary>
    /// <param name="damage">Desired loss of health</param>
    public void TakeHit(float damage)
    {
        health -= damage * (baseDefence * defence);
        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// This character's health increases by health
    /// </summary>
    /// <param name="health">This character's current health</param>
    public void Heal(float health)
    {
        this.health += health;
    }

    /// <summary>
    /// Sets this character's offence multipler to defence
    /// </summary>
    /// <param name="offence">The offence multipler desired</param>
    public void SetOffence(float offence)
    {
        this.offence = offence;
    }

    /// <summary>
    /// Returns this character's offence multiplier
    /// </summary>
    /// <returns>this character's offence multiplier</returns>
    public float GetOffence()
    {
        return offence;
    }

    /// <summary>
    /// Sets this character's defence multipler to defence
    /// </summary>
    /// <param name="defence">The defence multipler desired</param>
    public void SetDefence(float defence)
    {
        this.defence = defence;
    }

    /// <summary>
    /// Returns this character's defence multiplier
    /// </summary>
    /// <returns>this character's defence multiplier</returns>
    public float GetDefence()
    {
        return defence;
    }

    /// <summary>
    /// Kill this character
    /// </summary>
    public void Die()
    {
        dead = true;
    }

    /// <summary>
    /// End of turn stat adjustments
    /// </summary>
    public void onTurnEnd()
    {
        defence = startDefence;
        offence = startOffence;

        isTaunting = false;
    }
}
