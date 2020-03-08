﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnakeBrain : BaseBrain<SnakeBrain>
{
    public Animator enemyAnimator;
    public Transform raycastTransform;
    [SerializeField] public LayerMask WhatIsGround;


    public UnityAction Attacking;

    public float health;
    public float damage;
    public float speed;

    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartFight();
        }

        Debug.Log(currentState);
    }

    public void DealDamage()
    {
        Attacking?.Invoke();
    }


    public override void ChangeState(BaseState<SnakeBrain> newState)
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

    public void StartFight()
    {
        ChangeState(new FightState());
    }

    public void StartPatrol()
    {
        //enemyToFollow = objectToFollow;
        ChangeState (new PatrolState());
    }

    public void StartFollow()
    {
        ChangeState(new FollowState());
    }
}