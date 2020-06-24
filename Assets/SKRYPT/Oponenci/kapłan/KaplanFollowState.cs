using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaplanFollowState : BaseState<KaplanBrain>
{
    private KaplanBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    float PositionDifference;

    public override void InitState(KaplanBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;

        this.enemyAnimator = controller.enemyAnimator;
       brain.enemyAnimator.SetBool("iswalking", true);
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();


    }


    public override void UpdateState()
    {
        base.UpdateState();
        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        if (distance < brain.StartFightDist)
        {
            brain.StartAttack();
        }
        else if (distance > brain.StopFollowDist)
        {
            brain.StartPatrol();
        }


        if (Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.down, 2f, brain.WhatIsGround) && !Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.right, 2f, brain.WhatIsGround))
        {
            MoveTowardsPlayer();
        }

        else
        {
            enemyRigidBody2D.velocity = new Vector2(0, 0);
        }
    }

    public override void DeinitState(KaplanBrain controller)
    {
        base.DeinitState(controller);
        brain.enemyAnimator.SetBool("iswalking", false);
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
