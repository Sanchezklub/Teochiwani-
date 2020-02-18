using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHealth = 100;
    int currentHealth;
    [SerializeField]
    UnityEngine.Object destrutableRef;
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
        if (gameObject.name == "dzban")    
       {
           var coinRewarder = this.GetComponent<LootzDzbana>();
           if (coinRewarder != null) 
           {
               coinRewarder.Spawn();
           }
           ExplodeThisGameObject();
       }
        Destroy(gameObject);

    }
    private void ExplodeThisGameObject()
    {
        GameObject destrutable = (GameObject)Instantiate(destrutableRef);
        destrutable.transform.position = transform.position;
        Destroy(gameObject);

    }
   


}
