﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldmanBrain : BaseBrain<ShieldmanBrain>
{
    public SpriteRenderer sr;
    public Collider2D Shield;
    public float AttackRange;
    public Transform AttackPoint;
    public Transform raycastTransform;
    [SerializeField] public LayerMask WhatIsGround;
    public bool FacingRight;
    public float damage;
    public float speed;
    public float StartFollowDist;
    public float StopFollowDist;
    public float StartFightDist;
    public Animator enemyAnimator;

    public AudioSource audio;

    public AudioClip GettingHurt;
    public AudioClip Attacksound;
    public AudioClip Footstepsound;

    public UnityAction Attacking;
    public UnityAction LeaveFightState;

    private void Start()
    {
        //StartPatrol();
        StartPatrol();

    }
    private void Update()
    {
        UpdateChildState();

        //Debug.Log(currentState + "Shieldman State is");
    }

    public override void ChangeState(BaseState<ShieldmanBrain> newState)
    {
        base.ChangeState(newState);

        currentState?.DeinitState(this);
        currentState = newState;
        currentState?.InitState(this);
    }
    public override void UpdateChildState()
    {
        base.UpdateChildState();
        currentState?.UpdateState();
    }

    public void StartPatrol()
    {
        ChangeState(new ShieldmanPatrolState());
    }

    public void StartAttack()
    {
        //enemyToFollow = objectToFollow;
        ChangeState(new ShieldmanAttackState());
    }
    public void StartFollow()
    {
        ChangeState(new ShieldmanFollowState());
    }
    public void ActionAttack()
    {
        Attacking?.Invoke();
    }
    public void ActionLeaveFightState()
    {
        LeaveFightState?.Invoke();
    }
    public void SoundHurt()
    {
        AudioManager.instance.Play("Human Hurt 3");
    }
    public void SoundAttack()
    {
        AudioManager.instance.Play("Sword");
    }
    public void SoundFootStep()
    {
        AudioManager.instance.Play("Footstep");
    }
}
