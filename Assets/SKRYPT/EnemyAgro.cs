using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgro : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    Transform PlayerPos;
    [SerializeField]
    float agroRange;
    [SerializeField]
    float attackRange;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;
    [SerializeField]
    float attackjump;
    [SerializeField]
    float attackdamage=20;
    public float attackrate = 2f;
    float nextAttackTime=0f;
    public LayerMask enemyLayers;
    Health PlayerHealth;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = Player.GetComponent<Health>();
        PlayerPos = Player.GetComponent<Transform>();

    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position,PlayerPos.position);
        
        if(distToPlayer <agroRange && attackRange> agroRange)
        {
            ChasePlayer();
        }
        else if (distToPlayer <=attackRange )
        {       
            StopChasingPlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    private void ChasePlayer()
    {
        if(transform.position.x<PlayerPos.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed,0);
            transform.Rotate(0f,180f,0f);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed,0);
            transform.Rotate(0f,180f,0f);
        }

    }
    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(Time.time>=nextAttackTime)
        {   
            if (col.gameObject.name.Equals("Player"))
            {
            animator.SetBool ("Attack", true);
            PlayerHealth.TakeDamage(attackdamage);
            StopChasingPlayer();
            nextAttackTime = Time.time +1f / attackrate;
        }
      }   
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            animator.SetBool ("Attack", false);
        }
    }

}
