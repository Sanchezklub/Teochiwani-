using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    KapiBrain brain;
    void Start()
    {
        brain = GetComponentInParent<KapiBrain>();   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject?.GetComponent<PlayerHealth>().TakeDamage(brain.damage);
            gameObject.SetActive(false);
        }
    }

}
