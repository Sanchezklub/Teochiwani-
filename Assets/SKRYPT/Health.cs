using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthBar;
    public float MaxHealth=100;
    public float currentHealth;
    public Vector2 StartingPosition;
   
    void Start()
    {
        currentHealth=MaxHealth;
        healthBar.value = MaxHealth;
    }
     public void TakeDamage(float damage)
   {
       currentHealth -=damage;
        if (currentHealth<=0)
        {
            Debug.Log("Dead");
            Vector2 newPos = new Vector2(StartingPosition.x,StartingPosition.y ); 
            transform.position = newPos;
        }
   }
    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
    }
}
