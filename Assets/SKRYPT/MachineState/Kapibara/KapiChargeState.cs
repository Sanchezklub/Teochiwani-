using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapiChargeState : BaseState<KapiBrain>
{
    private KapiBrain brain;
    private GameObject player;
    Rigidbody2D enemyRigidBody2D;

    float PositionDifference;
    public override void InitState(KapiBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        //brain.enemyAnimator.SetBool("Idle", false);
        //brain.enemyAnimator.SetBool("Charge", true);

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

    public override void DeinitState(KapiBrain controller)
    {
        base.DeinitState(controller);
        brain.ChargeHitbox.SetActive(false);
        //brain.enemyAnimator.SetBool("Idle", true);
        //brain.enemyAnimator.SetBool("Charge", false);
    }


}
