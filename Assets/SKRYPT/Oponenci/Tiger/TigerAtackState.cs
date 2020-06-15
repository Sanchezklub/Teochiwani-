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
    public LayerMask Player;
    public float AnimationDuration = 0.8f;
    public float Speed;
    public bool twojstary;

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
        controller.LeaveFightState += speniaj;
        twojstary = false;

    }

public override void UpdateState()
    {
        if (twojstary == false)
        {
            //to go nie masz
            float distance = Vector3.Distance(brain.transform.position, player.transform.position);
            Speed = distance / AnimationDuration;
            if (brain.FacingRight)
                {
                    twojstary = true;
                    enemyRigidBody2D.velocity = new Vector2(Speed,20);
                }
            else
                {
                    twojstary = true;
                    enemyRigidBody2D.velocity = new Vector2(-1*Speed,20);
                }
        }
    }

public void dmg()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, Player);
        foreach (Collider2D enemy in hitEnemies)         
        {
        enemy.GetComponent<Health>()?.TakeDamage(AttackDamage);
        }
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

void speniaj()
    {
        brain.StartPatrol();
    }

public override void DeinitState(TigerBrain controller)
    {
        base.DeinitState(controller);
        brain.enemyAnimator.SetBool("IsPatrolling", true);
        brain.enemyAnimator.SetBool("IsAttacking", false);
        brain.enemyAnimator.SetBool("IsCharging", false);   
    }
}