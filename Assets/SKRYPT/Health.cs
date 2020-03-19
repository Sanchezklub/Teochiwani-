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
   
    protected virtual void Start()
    {
        currentHealth=MaxHealth;

    }
     public virtual void TakeDamage(float damage)
     {
       currentHealth -=damage;
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

    public virtual void ShowFloatingText(float damage)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = damage.ToString();
    }

}
