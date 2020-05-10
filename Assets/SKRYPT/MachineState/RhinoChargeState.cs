using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoChargeState : BaseState<RhinoBrain>
{
    private RhinoBrain brain;
    private GameObject player;
    Rigidbody2D enemyRigidBody2D;

    float PositionDifference;
    public override void InitState(RhinoBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.enemyAnimator.SetBool("Idle", false);
        brain.enemyAnimator.SetBool("Charge", true);

        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        if (!brain.ChargeHitbox.activeSelf)
        {
            brain.ChargeHitbox.SetActive(true);
        }


        StartCharge();
    }

    public void StartCharge()
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
        brain.FacingRight = !brain.FacingRight;
    }

    public override void UpdateState()
    {
        KeepCharging();
        DetectWall();
    }

    void KeepCharging()
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

    void DetectWall()
    {
//        Debug.Log("Detecting Wall");
        if (Physics2D.Raycast(brain.raycastTransform.position, new Vector2(enemyRigidBody2D.velocity.x*4,0), 0.1f, brain.WhatIsGround))
        {
            /*Vector2 Pos = brain.transform.position;
            if (brain.FacingRight)
            {
               brain.transform.position = Vector3.Lerp (Pos, new Vector2( brain.transform.position.x - 4, brain.transform.position.y), 10);
            }
            else
            {
                brain.transform.position = Vector3.Lerp(Pos, new Vector2(brain.transform.position.x + 4, brain.transform.position.y), 10);
            }
            */
            brain.StartStun();
        }
    }

    public override void DeinitState(RhinoBrain controller)
    {
        base.DeinitState(controller);
        brain.ChargeHitbox.SetActive(false);
        brain.enemyAnimator.SetBool("Idle", true);
        brain.enemyAnimator.SetBool("Charge", false);
    }


}
