﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldmanBrain : BaseBrain<ShieldmanBrain>
{
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

    public UnityAction Attacking;

    private void Start()
    {
        //StartPatrol();
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

        Debug.Log(currentState);
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
}