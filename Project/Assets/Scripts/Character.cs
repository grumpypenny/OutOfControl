using System.Collections;
using UnityEngine;

// This class is for any game object that needs stats such as health, defence, and offence
public class Character : MonoBehaviour, ICharacter<int>
{
    // Base stats
    public int startHealth;
    protected int health;

    public int startBaseDefence;
    protected int baseDefence;

    public int startBaseOffence;
    protected int baseOffence;

    // Base stat multipliers
    public int startDefence;
    protected int defence;

    public int startOffence;
    protected int offence;

    // Character states
    protected bool dead;

    // Start is called before the first frame update
    public virtual void Start()
    {
        health = startHealth;

        baseDefence = startBaseDefence;
        baseOffence = startBaseOffence;

        defence = startDefence;
        offence = startOffence;

        dead = false;
    }

    // Character takes damage damage
    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // Character gains health health
    public void Heal(int health)
    {
        this.health += health;
    }

    // Setters for base stat multipliers
    public void SetOffence(int offence)
    {
        this.offence = offence;
    }

    public void SetDefence(int defence)
    {
        this.defence = defence;
    }

    // Method executed on death of character
    public void Die()
    {
        dead = true;
        GameObject.Destroy(gameObject);
    }

}
