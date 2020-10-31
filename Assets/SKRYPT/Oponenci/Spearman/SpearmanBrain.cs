using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpearmanBrain : BaseBrain<SpearmanBrain>
{
    public Animator enemyAnimator;
    public Transform raycastTransform;
    public Transform AttackPoint;
    public Transform FirePoint;
    public GameObject Projectile;
    [SerializeField] public LayerMask WhatIsGround;


    public UnityAction Attacking;
    public UnityAction LeaveFightState;
    public UnityAction FacePlayerAction;

    //public AudioSource audio;
    //public AudioClip GettingHurt;
    //public AudioClip Attacksound;


    public float damage;
    public float speed;
    public float StartFollowDist;
    public float StopFollowDist;
    public float StartFightDist;
    public float AttackRange;
    public float MeleeDamageRange;

    public bool FacingRight;

    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

//        Debug.Log(currentState);
    }

    public void DealDamage()
    {
        Attacking?.Invoke();
    }

    public void AttemptToLeaveFightState()
    {
        LeaveFightState?.Invoke();
    }
    public void CallOnFacePlayer()
    {
        FacePlayerAction?.Invoke();
    }

    public override void ChangeState(BaseState<SpearmanBrain> newState)
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
    public void StartShot()
    {
        ChangeState(new SpearmanShotState());
    }


    public void StartPatrol()
    {
        //enemyToFollow = objectToFollow;
        ChangeState (new SpearmanPatrolState());
    }
    public void SoundHurt()
    {
        AudioManager.instance.Play("Human Damage 2");
    }
    public void SoundAttack()
    {
        AudioManager.instance.Play("Spear");
    }

    public void SoundFootstep()
    {
        AudioManager.instance.Play("Footstep 2");
    }
}