using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    float damage=100;
    void OnTriggerEnter2D( Collider2D col)
    {
       col.GetComponent<Health>().TakeDamage(damage);
    }
}
