using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerPatrolState : BaseState<TigerBrain>
{
   
    private TigerBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;


    public override void InitState(TigerBrain controller)
    {
        base.InitState(controller);
        // var renderer = controller.gameObject.GetComponent<MeshRenderer>();
        //  renderer.material.color = Color.green;
        this.brain = controller;

        //this.enemyAnimator = controller.enemyAnimator;
        //enemyAnimator.SetBool(Keys.WALK_ANIM_KEY, true);
        player = GameObject.Find("Player");
        controller.Attacking += DamageTaken;
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        brain.enemyAnimator.SetBool("IsPatrolling", true);
        brain.enemyAnimator.SetBool("IsAttacking", false);
      

    }

    public void DamageTaken()
    {
        brain.Attacking -= DamageTaken;
        //brain.StartFight();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float distance = Vector3.Distance(brain.transform.position, player.transform.position);

        if (distance < brain.StartFollowDist)
        {
            brain.StartChannelling();
        }


        //RaycastHit2D hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics2D.Raycast(brain.raycastTransform.position, Vector2.down, 5f, brain.WhatIsGround) && !Physics2D.Raycast(brain.raycastTransform.position, brain.raycastTransform.right, 5f, brain.WhatIsGround))
        {

            //Debug.DrawRay(brain.raycastTransform.position, Vector2.down * hit.distance, Color.yellow);

            //Debug.Log("Did Hit");
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

        //brain.transform.position = Vector3.Lerp(brain.transform.position, brain.enemyToFollow.position, Time.deltaTime * 2f);
    }

    public override void DeinitState(TigerBrain controller)
    {
        base.DeinitState(controller);
        brain.enemyAnimator.SetBool("IsCharging", true);
        brain.enemyAnimator.SetBool("IsPatrolling", false);
    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
}
