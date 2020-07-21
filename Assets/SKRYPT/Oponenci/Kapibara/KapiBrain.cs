using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KapiBrain : BaseBrain<KapiBrain>
{
    public float AttackRange;
    public Transform AttackPoint;
    public Transform raycastTransform;
    [SerializeField] public LayerMask WhatIsGround;
    public bool FacingRight;
    public float damage;
    public float speed;
    public float StartFollowDist;
    public float StopChargeDist;
    public Animator enemyAnimator;
    public float ChannellTime;
    public GameObject ChargeHitbox;
    public UnityAction Attacking;
    public UnityAction LeaveFightState;
    public AudioSource AttackSound;
    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

        //Debug.Log(currentState);
    }

    public override void ChangeState(BaseState<KapiBrain> newState)
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
        ChangeState(new KapiPatrolState());
    }

    public void StartChannelling()
    {
        ChangeState(new KapiChannellingState());
    }

    public void StartCharge()
    {
        //enemyToFollow = objectToFollow;
        ChangeState(new KapiChargeState());
    }

    public void ActionAttack()
    {
        Attacking?.Invoke();
    }
    public void ActionLeaveFightState()
    {
        LeaveFightState?.Invoke();
    }
    public void SoundAttack()
    {
        AttackSound.Play(0);
    }
}

        //stan patrol stan szarza ulanska stan channelling