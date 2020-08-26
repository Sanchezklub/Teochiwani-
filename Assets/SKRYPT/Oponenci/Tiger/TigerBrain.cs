using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TigerBrain : BaseBrain<TigerBrain>
{
    public float AttackRange;
    public Transform AttackPoint;
    public Transform raycastTransform;
    [SerializeField] public LayerMask WhatIsGround;
    public LayerMask PlayerLayer;
    public bool FacingRight;
    public float AttackDamage;
    public float speed;
    public float StartFollowDist;
    public float StopAttackDist;
    public Animator enemyAnimator;
    public float ChannellTime;
    public UnityAction Attacking;
    public UnityAction LeaveFightState;
    public float JD;
    public AudioSource ataksound;
    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

        //Debug.Log(currentState);
    }

    public override void ChangeState(BaseState<TigerBrain> newState)
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
        ChangeState(new TigerPatrolState());
    }

    public void StartChannelling()
    {
        ChangeState(new TigerChannellingState());
    }

    public void StartAttack()
    {
        //enemyToFollow = objectToFollow;
        ChangeState(new TigerAtackState());
    }

    public void ActionAttack()
    {
        Attacking?.Invoke();
    }
    public void ActionLeaveFightState()
    {
        LeaveFightState?.Invoke();
    }
}

