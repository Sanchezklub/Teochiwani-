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

        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();

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
        if (Physics2D.Raycast(new Vector2(brain.raycastTransform.position.x, brain.raycastTransform.position.y), Vector2.right, 2f, brain.WhatIsGround))
        {
            if (brain.FacingRight)
            {
                brain.transform.Translate(Vector3.right * 4);
            }
            else
            {
                brain.transform.Translate(Vector3.left * 4);
            }
            brain.StartStun();

        }
    }

    public override void DeinitState(RhinoBrain controller)
    {
        base.DeinitState(controller);
        brain.ChargeHitbox.SetActive(false);
    }


}
