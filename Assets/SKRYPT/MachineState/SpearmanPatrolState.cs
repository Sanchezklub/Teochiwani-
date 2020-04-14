﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearmanPatrolState : BaseState<SpearmanBrain>
{
    private SpearmanBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    

    public override void InitState(SpearmanBrain controller)
    {
        base.InitState(controller);
       // var renderer = controller.gameObject.GetComponent<MeshRenderer>();
      //  renderer.material.color = Color.green;
        this.brain = controller;

        this.enemyAnimator = controller.enemyAnimator;
        enemyAnimator?.SetBool("IsWalking",true);
        player = GameObject.Find("Player");
        controller.Attacking += DamageTaken;
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();   
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
            brain.StartShot();
        }
        

        //RaycastHit2D hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.down, 2f, brain.WhatIsGround) && !Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.right, 2f, brain.WhatIsGround))
        {

            //Debug.DrawRay(brain.raycastTransform.position, Vector2.down * hit.distance, Color.yellow);

            //Debug.Log("Did Hit");
            if(brain.FacingRight == true)
            {
                enemyRigidBody2D.velocity = new Vector2(1 * brain.speed, enemyRigidBody2D.velocity.y);
            }
            else
            {
                enemyRigidBody2D.velocity = new Vector2(-1 * brain.speed, enemyRigidBody2D.velocity.y);
            }

            
            
            
        } else
        {
            Flip();
        }

        //brain.transform.position = Vector3.Lerp(brain.transform.position, brain.enemyToFollow.position, Time.deltaTime * 2f);
    }

    public override void DeinitState(SpearmanBrain controller)
    {
        base. DeinitState(controller);
        enemyAnimator?.SetBool("IsWalking",false);
    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
}
