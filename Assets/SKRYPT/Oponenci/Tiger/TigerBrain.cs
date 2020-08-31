using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TigerBrain : BaseBrain<TigerBrain>
{
    public bool FacingRight;

    public float JD;
    public float speed;
    public float AttackRange;
    public float ChannellTime;
    public float AttackDamage;
    public float StartFollowDist;
    public float StopAttackDist;

    public Transform AttackPoint;
    public Transform raycastTransform;

    public LayerMask PlayerLayer;
    [SerializeField] public LayerMask WhatIsGround;

    public Animator enemyAnimator;

    public UnityAction Attacking;
    public UnityAction LeaveFightState;

    public AudioSource audio;
    public AudioClip Hurtsound;
    public AudioClip Deathsound;
    public AudioClip Attacksound;

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
    public void SoundDeath()
    {
        //audio.clip= Deathsound;
        //audio.Play();
        AudioManager.instance.Play("Tiger Die");
    }
    public void SoundHurt()
    {
        // nie ma animacji otrzymywania obrazen wykorzystuje jako dzwiek w stacie chanellingu 
        AudioManager.instance.Play("Tiger Hurt");
    }
    public void SoundAttack()
    {
        AudioManager.instance.Play("Tiger Attack");
    }
}

