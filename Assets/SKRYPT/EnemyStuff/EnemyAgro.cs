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
    float attackdelay;// time between start of the animation and the moment player recieves damage
    [SerializeField]
    float attackdamage = 20;
    public float attackrate = 3f; // how many seconds can pass between enemies attacks
    float nextAttackTime = 0f;
    public LayerMask enemyLayers;
    private bool FacingRight;
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
        float CurrentSpeed = rb2d.velocity.x;
        float distToPlayer = Vector2.Distance(transform.position, PlayerPos.position);

        if (distToPlayer < agroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }

        if (FacingRight == false && CurrentSpeed < 0)
        {
            Flip();
        }

        else if (FacingRight == true && CurrentSpeed > 0)
        {
            Flip();
        }

        nextAttackTime -= Time.deltaTime;

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

    IEnumerator OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            if (nextAttackTime < 0)
            {
                animator.SetBool("Attack", true);
                nextAttackTime = attackrate;
                yield return new WaitForSeconds(attackdelay);
                PlayerHealth.TakeDamage(attackdamage);
                StopChasingPlayer();
                yield return new WaitForSeconds(0.1f);
                animator.SetBool("Attack", false);

            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            animator.SetBool("Attack", false);
        }
    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        transform.Rotate(0f, 180f, 0f);

    }
}
