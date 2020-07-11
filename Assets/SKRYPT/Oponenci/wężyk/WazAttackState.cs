using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WazAttackState : BaseState<WazBrain>
{

    private WazBrain brain;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    float PositionDifference;

    public override void InitState(WazBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.enemyAnimator.SetBool("isfighting", true);
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        enemyRigidBody2D.velocity = new Vector2(0, 0);

        brain.Attacking += Attack;
        brain.LeaveFightState += AttemptLeavingFightState;

    }
    public override void UpdateState()
    {
        base.UpdateState();

    }

    public void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(brain.AttackPoint.position, brain.AttackRange);
        MoveTowardsPlayer();
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                Health player = hitColliders[i].GetComponent<Health>();
                player?.TakeDamage(brain.damage, brain.gameObject);
                brain.damage += 2;
                break;
            }

            i++;
        }

    }


    public override void DeinitState(WazBrain controller)
    {
        brain.Attacking -= Attack;
        brain.LeaveFightState -= AttemptLeavingFightState;
        brain.enemyAnimator.SetBool("isfighting", false);
        base.DeinitState(controller);
    }

    public void AttemptLeavingFightState()
    {
        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        if (distance > brain.StartFightDist)
        {
            brain.StartFollow();
        }
        else
        {
            brain.StartAttack();

        }
    }
    void MoveTowardsPlayer()
    {
        PositionDifference = brain.transform.position.x - player.transform.position.x;
        if (PositionDifference >= 0)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
            enemyRigidBody2D.velocity = new Vector2(-1 * brain.speed, enemyRigidBody2D.velocity.y);
            brain.FacingRight = false;
        }
        else if (PositionDifference <= 0)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            enemyRigidBody2D.velocity = new Vector2(1 * brain.speed, enemyRigidBody2D.velocity.y);
            brain.FacingRight = true;
        }

    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
    }
}
