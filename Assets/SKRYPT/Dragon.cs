using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    Transform PlayerPos;
    [SerializeField]
    float ScoutRange;
    [SerializeField]
    float attackRange;
    [SerializeField]
    float moveSpeed;
    Rigidbody2D rb2d;
    [SerializeField]
    float attackdelay;// time between start of the animation and the moment player recieves damage
    [SerializeField]
    float attackdamage = 20;
    public float attackrate = 3f; // how many seconds can pass between enemies attacks
    float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    private bool FacingRight;
    Health PlayerHealth;
    public Transform FirePoint;
    
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = Player.GetComponent<Health>();
        PlayerPos = Player.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        float CurrentSpeed = rb2d.velocity.x;
        float distToPlayer = Vector2.Distance(transform.position, PlayerPos.position);
        if ( ScoutRange < distToPlayer  && distToPlayer > attackRange)
        {
            ChasePlayer();
        }
        if (distToPlayer<attackRange)
        {
            Attack();
            StopChasingPlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    private void ChasePlayer()
    {
        if (transform.position.x < PlayerPos.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
        }

    }

    private void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
    }
    IEnumerator Attack()
    {
       if (nextAttackTime < 0)
        {
                animator.SetBool("Attack", true);
                nextAttackTime = attackrate;
                yield return new WaitForSeconds(attackdelay);

                Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(FirePoint.position,attackRange,enemyLayers); 
                foreach (Collider2D col in hitEnemies)
                {
                col.GetComponent<Health>().TakeDamage(attackdamage);
                col.GetComponent<Enemy>().TakeDamage(attackdamage);
                }
                yield return new WaitForSeconds(0.1f);
                animator.SetBool("Attack", false);

        }


    }
}
