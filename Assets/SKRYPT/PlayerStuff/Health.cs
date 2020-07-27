using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float MaxHealth=100;
    public float currentHealth;
    public bool FloatingText;
    public GameObject FloatingTextPrefab;
    public int id;
   // public Color ColorWith0hp;
  //  public Color ColorWith100hp;
    public ParticleSystem Poison;
    public SplashController splashController;
    protected virtual void Start()
    {
        currentHealth=MaxHealth;
        splashController=GetComponent<SplashController>();
    }
     public virtual void TakeDamage(float damage, GameObject attacker = null)
     {
       currentHealth -=damage;
       splashController?.MakeSplat();
        if (FloatingText == true)
        {
            ShowFloatingText(damage);
        }
        if (currentHealth<=0)
        {
            Die();     
        }

     }

    protected virtual void Die() {
    
    }
    public virtual void PoisonEffect(float damage, int TimeCount, float TimeBetweenHits)
    {
      
        StartCoroutine(PoisonDamage(damage,  TimeCount, TimeBetweenHits)) ;
    }

    //add this to update area

    IEnumerator PoisonDamage(float damage,  int TimeCount, float TimeBetweenHits)
    {
        var go =Instantiate(Poison, new Vector2( transform.position.x, transform.position.y+7), Quaternion.identity,transform);
        Destroy ( go,TimeCount*TimeBetweenHits );
        for ( int i=0; i < TimeCount; i++)
        {
            yield return new WaitForSeconds(TimeBetweenHits) ;
            TakeDamage(damage);
        }
    }
 

    public virtual void ShowFloatingText(float damage)
    {
        var go = Instantiate(FloatingTextPrefab, new Vector2( transform.position.x, transform.position.y+3), Quaternion.identity);
        go.GetComponent<TextMesh>().text = damage.ToString();
        if (currentHealth <= 0)
        {
            go.GetComponent<TextMesh>().color=new Color( (221/255), (31/255), (13/255), 1);
        }
        else 
        {
            go.GetComponent<TextMesh>().color=new Color((140 - currentHealth/MaxHealth  * 140 + 81 )/255, (currentHealth/MaxHealth  * 153 + 31)/255 , 13/255, 1);
        }
    }

}
