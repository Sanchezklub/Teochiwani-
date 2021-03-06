﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TigerAtackState : BaseState<TigerBrain>
{
    private TigerBrain brain;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    public Animator enemyAnimator;
    public float AttackRange;
    public Transform AttackPoint;
    public float AttackDamage;
    public LayerMask PlayerLayer;
    public float AnimationDuration = 0.8f;
    public float Speed;
    public bool twojstary;
    //public int JD;

 public override void InitState(TigerBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.enemyAnimator.SetBool("IsAttacking", true);
        brain.enemyAnimator.SetBool("IsCharging", false);

        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        FaceTowardsPlayer();
        controller.Attacking += dmg;
        controller.LeaveFightState += AttemptLeavingFightState;
        twojstary = false;
        //brain.head.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0 ,1);

    }

public override void UpdateState()
    {
        if (twojstary == false)
        {
            //to go nie masz
            float distance = Mathf.Abs(brain.transform.position.x - player.transform.position.x);
            Speed = distance / AnimationDuration;
            if (brain.FacingRight)
                {
                    twojstary = true;
                    enemyRigidBody2D.velocity = new Vector2(Speed,brain.JD);
                }
            else
                {
                    twojstary = true;
                    enemyRigidBody2D.velocity = new Vector2(-1*Speed,brain.JD);
                }
        }
    }

public void dmg()
    {
        Collider2D hitEnemies = Physics2D.OverlapCircle(brain.AttackPoint.position, brain.AttackRange, brain.PlayerLayer);

        hitEnemies?.GetComponent<Health>()?.TakeDamage(brain.AttackDamage);
        Debug.Log("!jd");
        //brain.ataksound.Play(0);
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

void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }


    public void AttemptLeavingFightState()
    {
        float distance = Mathf.Abs(Vector3.Distance(brain.transform.position, player.transform.position));
        //Debug.Log("Attempted to leave FightState. Distance was:" + distance);
        if (distance > brain.StartFollowDist)
        {
            //Debug.Log("left fightstate");
            brain.StartPatrol();
        }
        else
        {
            brain.StartChannelling();

        }
    }

public override void DeinitState(TigerBrain controller)
    {
        brain.Attacking -= dmg;
        brain.LeaveFightState -= AttemptLeavingFightState;
        base.DeinitState(controller);
        brain.enemyAnimator.SetBool("IsPatrolling", true);
        brain.enemyAnimator.SetBool("IsAttacking", false);
        brain.enemyAnimator.SetBool("IsCharging", false);   
    }
}
