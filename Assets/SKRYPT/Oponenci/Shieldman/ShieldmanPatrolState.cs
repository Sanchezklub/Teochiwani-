using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldmanPatrolState : BaseState<ShieldmanBrain>
{
    private ShieldmanBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;


    public override void InitState(ShieldmanBrain controller)
    {
        base.InitState(controller);
        // var renderer = controller.gameObject.GetComponent<MeshRenderer>();
        //  renderer.material.color = Color.green;
        this.brain = controller;


        brain.enemyAnimator.SetBool("iswalking", true);
        player = GameObject.Find("Player");
        controller.Attacking += DamageTaken;
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        if (brain.FacingRight == false)
        {
            //brain.transform.Rotate(new Vector2(0f, 180f));
        }
                //brain.sr.color = new Color(0, 0, 1 ,1);
    }

    public void DamageTaken()
    {
        brain.Attacking -= DamageTaken;
        brain.StartAttack();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float distance = Mathf.Abs(Vector3.Distance(brain.transform.position, player.transform.position));

        if (distance < brain.StartFollowDist)
        {
            brain.StartFollow();
        }

        //RaycastHit2D hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics2D.Raycast(brain.raycastTransform.position, Vector2.down, 2f, brain.WhatIsGround) && !Physics2D.Raycast(brain.raycastTransform.position, brain.raycastTransform.right, 5f, brain.WhatIsGround))
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

    public override void DeinitState(ShieldmanBrain controller)
    {
        base.DeinitState(controller);
        brain.enemyAnimator.SetBool("iswalking", false);
    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
}
