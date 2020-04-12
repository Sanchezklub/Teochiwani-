﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldmanAttackState : BaseState<ShieldmanBrain>
{
    private Collider2D Shield;
    private ShieldmanBrain brain;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;

    public override void InitState(ShieldmanBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        Shield = brain.GetComponentInChildren<Collider2D>();
        Shield.enabled = false;
        brain.enemyAnimator.SetBool("isfighting", true);
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        enemyRigidBody2D.velocity = new Vector2(0, 0);

        controller.Attacking += Attack;
        //brain.LeaveFightState += AttemptLeavingFightState;

    }
    public override void UpdateState()
    {
        base.UpdateState();

    }

    public void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(brain.AttackPoint.position, brain.AttackRange);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                Health player = hitColliders[i].GetComponent<Health>();
                player?.TakeDamage(brain.damage);
                break;
            }

            i++;
        }

    }


    public override void DeinitState(ShieldmanBrain controller)
    {
        brain.Attacking -= Attack;
       // brain.LeaveFightState -= AttemptLeavingFightState;
        brain.enemyAnimator.SetBool("isfighting", false);
        Shield.enabled = true;
        base.DeinitState(controller);
    }

    public void AttemptLeavingFightState()
    {
        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        if (distance > brain.StartFightDist)
        {
            brain.StartFollow();
        }
    }
}