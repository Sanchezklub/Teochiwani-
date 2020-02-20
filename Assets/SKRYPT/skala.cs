using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skala : MonoBehaviour
{
    public int MaxHealth = 100;
    int currentHealth;
    public Sprite mysprite1;
    public Sprite mysprite2;
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = MaxHealth;
    }

   
    public void TakeDamage(int damage)
    {
       currentHealth -=damage;
        if (currentHealth==40 )
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite1;
        }
        else if (currentHealth ==25 )
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite2;
        }
        else if (currentHealth<=0)
        {
            Die();
        }
    }

    void Die ()
    {
        
        Destroy(gameObject);

    }
}
