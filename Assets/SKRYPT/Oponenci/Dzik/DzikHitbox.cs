using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DzikHitbox : MonoBehaviour
{
    [SerializeField] private BoxCollider2D coll;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(GetComponentInParent<Dzik>().damage);
            coll.enabled = false;
        }
        
    }
}
