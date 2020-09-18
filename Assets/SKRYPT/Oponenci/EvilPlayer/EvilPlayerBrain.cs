using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerBrain : BaseBrain<EvilPlayerBrain>
{
    public Animator animator;
    public Rigidbody2D rb;
    public Transform RaycastTransform;
    public LayerMask WhatIsGround;
    //public float damage;
    //public float speed;
    //public float jumpheight;
    public EvilPlayerCombat combat;

    public float AggroRange;
    public float AttackDist;
    public float RangedAttackDist;
    public bool FacingRight;


    private void Start()
    {
        StartIdle();
        Debug.Log("Evil player started idle");
    }
    public void StartIdle()
    {
        ChangeState(new EvilPlayerIdleState());
    }
    public void StartFollow()
    {
        ChangeState(new EvilPlayerFollowState());
    }

    public void StartAttack()
    {
        ChangeState(new EvilPlayerAttackState());
    }
    public override void ChangeState(BaseState<EvilPlayerBrain> newState)
    {
        Debug.LogFormat("EvilPlayer:: Old state was {0}. New state is {1}", currentState, newState);
        base.ChangeState(newState);
        currentState?.DeinitState(this);
        currentState = newState;
        currentState?.InitState(this);
    }
    private void Update()
    {
        UpdateChildState();
    }
    public override void UpdateChildState()
    {
        base.UpdateChildState();
        currentState?.UpdateState();
    }
}
