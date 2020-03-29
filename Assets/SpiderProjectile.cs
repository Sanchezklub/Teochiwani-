using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderProjectile : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private float moveSpeed = 7f;
    Rigidbody2D rb;
    
    GameObject target;
    Vector2 moveDirection;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.Find("Player");
        Debug.Log("1"); 
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        Debug.Log("2");
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Debug.Log("3");
        //transform.LookAt(target.transform);
        Debug.Log("4");
        Destroy(gameObject, 3f); 


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Debug.Log("SpiderProjectile :: HIT");
            Destroy(gameObject);
        }
    }
}
