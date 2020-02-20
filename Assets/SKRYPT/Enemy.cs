using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int MaxHealth = 100;
    int currentHealth;
    public Sprite mysprite1;
    public Sprite mysprite2;
    [SerializeField]
    UnityEngine.Object destrutableRef;  
    [SerializeField]
    public GameObject Particle;
    void Start()
    {
        currentHealth =  MaxHealth;
    }

   public void TakeDamage(int damage)
   {
       currentHealth -=damage;
       if(gameObject.name == "skala")
       {
          Instantiate(this.Particle, this.transform.position, Quaternion.identity);

       }
       if(gameObject.name == "skala" && currentHealth>=40 && currentHealth<=100 )
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite1;
        }
        else if (gameObject.name == "skala" && currentHealth>0 && currentHealth<39  )
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite2;
        }
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
