using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBrain : BaseBrain<SpiderBrain>
{
    public Animator enemyAnimator;
    public Transform raycastTransform;
    public Transform AttackPoint;
    public Transform FirePoint;
    [SerializeField] public LayerMask WhatIsGround;


    public float MaxHealth;
    public float CurrentHealth;
    public float damage;
    public float speed;
    public float StartFollowDist;
    public float StopFollowDist;
    public float StartFightDist;
    public float AttackRange;

    [SerializeField]
    public GameObject SpiderProjectile;

    public float Rate;
    public float nextFire;
    public float fireRate;

    public bool FacingRight;

    private void Start()
    {
        //StartPatrol();
        StartShoot();
    }
    private void Update()
    {
        UpdateChildState();

        Debug.Log(currentState);
    }

    public override void ChangeState(BaseState<SpiderBrain> newState)
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

    public void StartShoot()
    {
        ChangeState(new SpiderShootState());
    }

    public void StartJump()
    {
        //enemyToFollow = objectToFollow;
        ChangeState(new SpiderJumpState());
    }

}
