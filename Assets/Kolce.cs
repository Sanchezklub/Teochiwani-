﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolce : MonoBehaviour
{
    public float damage=100;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Health>()?.TakeDamage(damage);
        }

    }

 
}