using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapiChannellingState : BaseState<KapiBrain>
{
    private KapiBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    private float ChannellingTime;
    public override void InitState(KapiBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
       
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        enemyRigidBody2D.velocity = Vector2.zero;
        FaceTowardsPlayer();
        brain.enemyAnimator.SetBool("isIdle", true);
        brain.enemyAnimator.SetBool("isCharging", false);
    }

        void FaceTowardsPlayer()
    {
        float PositionDifference = brain.transform.position.x - player.transform.position.x;
        if(PositionDifference >= 0)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
        }
        else if (PositionDifference <= 0)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
        }
    }
    public override void UpdateState()
    {
        TimeCheck();
    }

    private void TimeCheck()
    {
        ChannellingTime += Time.deltaTime;
        if (ChannellingTime > brain.ChannellTime)
        {
            brain.StartCharge();
        }
    }


    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
    public override void DeinitState(KapiBrain controller)
    {
        base.DeinitState(controller);
    }
}

