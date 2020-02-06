using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHealth = 100;
    int currentHealth;
    void Start()
    {
        currentHealth =  MaxHealth;
    }

   public void TakeDamage(int damage)
   {
       currentHealth -=damage;
        if (currentHealth<=0)
        {
            Die();


        }
   }

    void Die ()
    {
           GetComponent<Collider2D>().enabled = false;
           GetComponent<SpriteRenderer>().color =Color.red;
           this.enabled = false;

    }
   





}
