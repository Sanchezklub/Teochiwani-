using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolotlBlood : MonoBehaviour
{
    public GameObject Xolotl;
    private float damage;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D bc;
        bc = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
       damage = Xolotl.GetComponent<XolotlBrain>().BloodDamage;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<Health>().TakeDamage(damage, Xolotl); 
    }
}
