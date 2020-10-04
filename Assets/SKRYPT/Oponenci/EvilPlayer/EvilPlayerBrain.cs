using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public GameObject SpearPrefab;
    public Transform throwPosition;

    public float AggroRange;
    public float AttackDist;
    public float RangedAttackDist;
    public bool FacingRight;

    public UnityAction evilSpearAttack;

    private void Start()
    {
        StartIdle();
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
    public void FootstepSound()
    {
        AudioManager.instance.Play("Footstep 3");
    }

    public void EvilSpearAttack()
    {
        evilSpearAttack?.Invoke();
    }
}
