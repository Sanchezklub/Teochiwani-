using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WazBrain : BaseBrain<WazBrain>
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
    public UnityAction LeaveFightState;

    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();
    }

    public override void ChangeState(BaseState<WazBrain> newState)
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
        ChangeState(new WazPatrolState());
    }

    public void StartAttack()
    {

        ChangeState(new WazAttackState());
    }
    public void StartFollow()
    {
        ChangeState(new WazFollowState());
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
