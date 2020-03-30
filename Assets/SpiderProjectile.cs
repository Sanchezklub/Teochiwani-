using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderProjectile : MonoBehaviour
{
    public float damage;
    [SerializeField]
    private float moveSpeed = 7f;
    Rigidbody2D rb;
    private float targ_x;
    private float targ_y;
    
    GameObject target;
    Vector2 moveDirection;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        target = GameObject.Find("Player");
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Vector3 objectPos = transform.position;
        targ_x = target.transform.position.x - objectPos.x;
        targ_y = target.transform.position.y - objectPos.y;

        float angle = Mathf.Atan2(targ_y, targ_x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
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
