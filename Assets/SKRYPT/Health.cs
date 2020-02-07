using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthBar;
    public float MaxHealth=100;
    public float currentHealth;
   
    void Start()
    {
        currentHealth=MaxHealth;
        healthBar.value = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currentHealth;
    }
}
