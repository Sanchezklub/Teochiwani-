using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragonBrain : BaseBrain<DragonBrain>
{
    public Animator enemyAnimator;
    public Transform raycastTransform;
    [SerializeField] public LayerMask WhatIsGround;
    public float speed;
    public float AggroDist;
    public float StartAttackDist;
    public bool FacingRight;
    public GameObject Flame;
    public UnityAction Attacking;
    public UnityAction LeaveFightState;
    public Transform Firepoint;
    public float dmg;
    public float EscapeTime;

    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

        Debug.Log("Dragons current state is:" + currentState);

//        Debug.Log(currentState);
    }
    public override void ChangeState(BaseState<DragonBrain> newState)
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
        ChangeState(new DragonPatrol());
    }

    public void StartAttack()
    {
        ChangeState(new DragonAttack());
    }

    public void StartEscape()
    {
        ChangeState(new DragonEscape());
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
