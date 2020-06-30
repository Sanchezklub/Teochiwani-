using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEscape : BaseState<DragonBrain>
{
    private DragonBrain brain;
    public float EscapingTime;
    public float PositionDifference;
    private GameObject player;
    private Rigidbody2D enemyRigidBody2D;

public override void InitState(DragonBrain controller)
    {   
        base.InitState(controller);
        this.brain = controller;
        brain.enemyAnimator.SetBool("Patrol", true);
        brain.enemyAnimator.SetBool("Attack", false);
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        EscapingTime = 0;
    }

    public override void UpdateState()
    {
        TimeCheck();
        if (Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.down, 6f, brain.WhatIsGround) && !Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.right, 2f, brain.WhatIsGround))
        {
            run();
        }
    }

    void run()
    {
        PositionDifference = brain.transform.position.x - player.transform.position.x;
        if (PositionDifference <= 0)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
            enemyRigidBody2D.velocity = new Vector2(-1 * brain.speed, enemyRigidBody2D.velocity.y);
            brain.FacingRight = false;
        }
        else if (PositionDifference >= 0)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            enemyRigidBody2D.velocity = new Vector2(1 * brain.speed, enemyRigidBody2D.velocity.y);
            brain.FacingRight = true;
        }
    }

    private void TimeCheck()
    {
        EscapingTime += Time.deltaTime;
        if (EscapingTime > brain.EscapeTime)
        {
            PositionDifference = brain.transform.position.x - player.transform.position.x;
        if (Mathf.Abs(PositionDifference) >= brain.AggroDist)
            {
                brain.StartPatrol();
            }
            else
            {
                brain.StartAttack();
            }
        }
    }
        void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
        public override void DeinitState(DragonBrain controller)
    {
        base.DeinitState(controller);
    }

}