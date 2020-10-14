using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerChannellingState : BaseState<TigerBrain>
{
    private TigerBrain brain;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    private float ChannellingTime;
    public override void InitState(TigerBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;

        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        enemyRigidBody2D.velocity = Vector2.zero;
        FaceTowardsPlayer();
        brain.enemyAnimator.SetBool("IsCharging", true);
        brain.enemyAnimator.SetBool("IsPatrolling", false);
        ChannellingTime = 0;
        //brain.head.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0 ,1);
    }

    void FaceTowardsPlayer()
    {
        float PositionDifference = brain.transform.position.x - player.transform.position.x;
        if (PositionDifference >= 0)
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
        FaceTowardsPlayer();
    }

    private void TimeCheck()
    {
        ChannellingTime += Time.deltaTime;
        if (ChannellingTime > brain.ChannellTime)
        {
            brain.StartAttack();
        }
    }


    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
    public override void DeinitState(TigerBrain controller)
    {
        base.DeinitState(controller);
        brain.enemyAnimator.SetBool("IsCharging", false);
        brain.enemyAnimator.SetBool("IsAttacking", true);
    }
}
