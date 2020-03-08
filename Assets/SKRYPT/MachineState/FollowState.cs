using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : BaseState<SnakeBrain>
{
    private SnakeBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    float PositionDifference;

    public override void InitState(SnakeBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;

        this.enemyAnimator = controller.enemyAnimator;
        enemyAnimator.SetBool(Keys.PATROL_ANIM_KEY, true);
        player = GameObject.Find("Player");
        controller.Attacking += DamageTaken;
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
    }

    public void DamageTaken()
    {
        brain.Attacking -= DamageTaken;
        brain.StartFight();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        if (distance < 5)
        {
            brain.StartFight();
        }
        if (Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.down, 2f, brain.WhatIsGround))
        {
            Debug.Log("Did hit");
            MoveTowardsPlayer();

        }

        else{
            Debug.Log("Did not");
            // tutaj dać zmianę na animację idlowania gdyby była

        }
    }

    public override void DeinitState(SnakeBrain controller)
    {
        base.DeinitState(controller);
    }

    void MoveTowardsPlayer()
    {
        PositionDifference = brain.transform.position.x - player.transform.position.x;
        if(PositionDifference <= 0)
        {
            enemyRigidBody2D.velocity = Vector2.left * brain.speed;             
        }
        else if (PositionDifference >= 0)
        {
            enemyRigidBody2D.velocity = Vector2.right * brain.speed;
        }
       
    }
}
