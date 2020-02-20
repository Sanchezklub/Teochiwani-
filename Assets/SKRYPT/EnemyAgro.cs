using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position,player.position);
        
        if(distToPlayer <agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    private void ChasePlayer()
    {
        if(transform.position.x<player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed,0);
            transform.localScale = new Vector2(2,2);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed,0);
            transform.localScale = new Vector2(-2,2);
        }

    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }


}
