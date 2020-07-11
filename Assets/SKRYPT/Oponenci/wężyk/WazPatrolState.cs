using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WazPatrolState : BaseState<WazBrain>
{

    private WazBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;


    public override void InitState(WazBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;


        //brain.enemyAnimator.SetBool("iswalking", true);
        player = GameObject.Find("Player");
        controller.Attacking += DamageTaken;
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        if (brain.FacingRight == false)
        {
            brain.transform.Rotate(new Vector2(0f, 180f));
        }
    }

    public void DamageTaken()
    {
        brain.Attacking -= DamageTaken;
        brain.StartAttack();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float distance = Vector3.Distance(brain.transform.position, player.transform.position);

        if (distance < brain.StartFollowDist)
        {
            brain.StartFollow();
        }


        if (Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.down, 5f, brain.WhatIsGround) && !Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.right, 2f, brain.WhatIsGround))
        {
            if (brain.FacingRight == true)
            {
                enemyRigidBody2D.velocity = new Vector2(1 * brain.speed, enemyRigidBody2D.velocity.y);
            }
            else
            {
                enemyRigidBody2D.velocity = new Vector2(-1 * brain.speed, enemyRigidBody2D.velocity.y);
            }
        }

        else
        {
            Flip();
        }
    }

    public override void DeinitState(WazBrain controller)
    {
        base.DeinitState(controller);
        //brain.enemyAnimator.SetBool("iswalking", false);
    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
}
