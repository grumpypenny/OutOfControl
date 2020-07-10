using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is for any game object that needs stats such as health, defence, and offence
public class Character : MonoBehaviour, ICharacter<int>
{
    public int startHealth;
    protected int health;

    public int startDefence;
    protected int defence;

    public int startOffence;
    protected int offence;

    protected bool dead;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = startHealth;
        defence = startDefence;
        offence = startOffence;

        dead = false;
    }

    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int health)
    {
        this.health += health;
    }

    public void SetOffence(int offence)
    {
        this.offence = offence;
    }

    public void SetDefence(int defence)
    {
        this.defence = defence;
    }

    public void Die()
    {
        dead = true;
    }
}
