using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBrain : BaseBrain<EnemyBrain>
{
    public Animator enemyAnimator;
    public Transform raycastTransform;
    public Transform AttackPoint;
    [SerializeField] public LayerMask WhatIsGround;


    public UnityAction Attacking;
    public UnityAction LeaveFightState;

    public float MaxHealth;
    public float CurrentHealth;
    public float damage;
    public float speed;
    public float StartFollowDist;
    public float StopFollowDist;
    public float StartFightDist;
    public float AttackRange;

    public bool FacingRight;

    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

        Debug.Log(currentState);
    }

    public void DealDamage()
    {
        Attacking?.Invoke();
    }

    public void AttemptToLeaveFightState()
    {
        LeaveFightState?.Invoke();
    }


    public override void ChangeState(BaseState<EnemyBrain> newState)
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
