using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolotlHitbox : MonoBehaviour
{
    XolotlBrain brain;
    void Start()
    {
        brain = GetComponentInParent<XolotlBrain>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject?.GetComponent<PlayerHealth>().TakeDamage(brain.DashDamage);
            gameObject.SetActive(false);
        }
    }

}
