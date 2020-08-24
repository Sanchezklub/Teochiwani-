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
   // public ParticleSystem Poison;
    public ParticleSystem[] EffectParticle;
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
    public virtual void Effect(float damage, int TimeCount, float TimeBetweenHits, int Effect)
    {
        if ( Effect == 0)
        {
        StartCoroutine(PoisonDamage(damage,  TimeCount, TimeBetweenHits)) ;
        }
        else if ( Effect ==1 )
        {
        StartCoroutine(FlameDamage(damage,  TimeCount, TimeBetweenHits)) ;
        }
        else if ( Effect ==2 )
        {
        StartCoroutine(BleedingDamage(damage,  TimeCount, TimeBetweenHits)) ;
        }
    }
    

    IEnumerator PoisonDamage(float damage,  int TimeCount, float TimeBetweenHits)
    {
        var go =Instantiate(EffectParticle[0], new Vector2( transform.position.x, transform.position.y+7), Quaternion.identity,transform);
        Destroy ( go,TimeCount*TimeBetweenHits );
        for ( int i=0; i < TimeCount; i++)
        {
            yield return new WaitForSeconds(TimeBetweenHits) ;
            TakeDamage(damage);
            EventController.instance.enemyEvents.CallOnPoisonDamageDealt(damage);
        }
    }


    IEnumerator FlameDamage(float damage,  int TimeCount, float TimeBetweenHits)
    {
        var go =Instantiate(EffectParticle[1], new Vector2( transform.position.x, transform.position.y+7), Quaternion.identity,transform);
        Destroy ( go,TimeCount*TimeBetweenHits );
        for ( int i=0; i < TimeCount; i++)
        {
            yield return new WaitForSeconds(TimeBetweenHits) ;
            TakeDamage(damage);
            EventController.instance.enemyEvents.CallOnFireDamageDealt(damage);
        }
    }

    
    IEnumerator BleedingDamage(float damage,  int TimeCount, float TimeBetweenHits)
    {
        var go =Instantiate(EffectParticle[2], new Vector2( transform.position.x, transform.position.y+7), Quaternion.identity,transform);
        Destroy ( go,TimeCount*TimeBetweenHits );
        for ( int i=0; i < TimeCount; i++)
        {
            yield return new WaitForSeconds(TimeBetweenHits) ;
            TakeDamage(damage);
            EventController.instance.enemyEvents.CallOnBleedDamageDealt(damage);
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
