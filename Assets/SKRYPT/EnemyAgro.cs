using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    Transform player;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;
    [SerializeField]
    float attackjump;
    [SerializeField]
    float attackdamage=20;
    public float attackrate = 2f;
    float nextAttackTime=0f;
    
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
              new WaitForSecondsRealtime(5);
            AttackPlayer();
            StopChasingPlayer();
            
        }
    }
    void AttackPlayer()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        Player.Health().TakeDamage(attackdamage);
        if(transform.position.x<player.position.x)
        {
            rb2d.velocity = new Vector2(attackjump,0);
            transform.localScale = new Vector2(1,1);
        }
        else
        {
            rb2d.velocity = new Vector2(-attackjump,0);
            transform.localScale = new Vector2(-1,1);
        }
        
    }
    private void ChasePlayer()
    {
        if(transform.position.x<player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed,0);
            transform.localScale = new Vector2(1,1);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed,0);
            transform.localScale = new Vector2(-1,1);
        }

    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }


}
