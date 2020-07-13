using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class FalseGodsBrain : BaseBrain<FalseGodsBrain>
{

    public float AggroRange;
    public float MovementSpeed;
    public float ProjectileDmg;
    public float BallDmg;
    public float RunTime;


    public float ProjectileMinX;
    public float ProjectileMaxX;
    public float ProjectileY;

    public int ProjectileAmount;

    public Animator TulioAnimator;
    public Animator MiguelAnimator;

    public Rigidbody2D TulioRb;
    public Rigidbody2D MiguelRb;

    public Rigidbody2D rb;

    public bool FacingRight;

    public Transform RaycastTransform;
    public Transform HandTransform;
    public Transform BallPoint;

    public UnityAction Attacking;
    public UnityAction EndAttack;

    public LayerMask WhatIsGround;

    public GameObject Projectile;
    public GameObject ball;

    private void Start()
    {
        StartIdle();
    }
    private void Update()
    {
        UpdateChildState();

        //Debug.Log(currentState);
    }

    public override void ChangeState(BaseState<FalseGodsBrain> newState)
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
        ChangeState(new FalseGodsIdleState());
    }

    public void StartRun()
    {
        ChangeState(new FalseGodsRunState());
    }

    public void StartPrayer()
    {
        ChangeState(new FalseGodsPrayerState());
    }

    public void StartBall()
    {
        ChangeState(new FalseGodsBallState());
    }

    public void ActionAttack()
    {
        Debug.Log("FalseGodsBrain :: ActionAttack called");
        Attacking?.Invoke();
    }

    public void ActionEndAttack()
    {
        EndAttack?.Invoke();
    }
}
