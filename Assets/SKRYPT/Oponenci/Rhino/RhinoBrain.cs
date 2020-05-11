using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RhinoBrain : BaseBrain<RhinoBrain>
{
    public Animator enemyAnimator;
    public Transform raycastTransform;
    public Transform StompAttackPoint;
    public GameObject ChargeHitbox;
    public GameObject RhinoCollider;
    [SerializeField] public LayerMask WhatIsGround;
    public UnityAction Stomp;

    public float ChargeDamage;
    public float StompDamage;
    public float speed;
    public float StunTime;
    public float StompRange;
    public float StompDist;
    public float AggroDist;
    public float VerStompKnockback;
    public float HorStompKnockback;

    public bool FacingRight;

    private void Start()
    {
        StartStun();
    }
    private void Update()
    {
        UpdateChildState();

//        Debug.Log(currentState);
    }

    public void DoAttack()
    {
        Stomp?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState?.StateOnCollisonEnter2D(collision);
    }


    public override void ChangeState(BaseState<RhinoBrain> newState)
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

    public void StartIdle()
    {
        ChangeState(new RhinoIdleState());
    }

    public void StartCharge()
    {
        ChangeState(new RhinoChargeState());
    }

    public void StartStomp()
    {
        ChangeState(new RhinoStompState());
    }
    public void StartStun()
    {
        ChangeState(new RhinoStunState());
    }
}
