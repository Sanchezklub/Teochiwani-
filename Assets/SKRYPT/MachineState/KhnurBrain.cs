using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class KhnurBrain : BaseBrain<KhnurBrain>

{
    public float AttackRange;
    public Transform AttackPoint;
    public Transform raycastTransform;
    [SerializeField] public LayerMask WhatIsGround;
    public bool FacingRight;
    public float damage;
    public float speed;
    public float StartFollowDist;
    public float StopFollowDist;
    public float StartFightDist;
    public int SummonCount = 0;
    public Animator enemyAnimator;
    public Transform FirePoint;
    public float fireRate;
    public float nextFire;
    public GameObject Dzik;

    public UnityAction Attacking;
    public UnityAction LeaveFightState;

    private void Start()
    {
        //StartPatrol();
        StartAtak1();
    }
    private void Update()
    {
        UpdateChildState();

        Debug.Log(currentState);
    }

    public override void ChangeState(BaseState<KhnurBrain> newState)
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

    public void StartAtak1()
    {
        ChangeState(new KhnurAtak1());
    }

    public void StartAtak2()
    {
        //enemyToFollow = objectToFollow;
        ChangeState(new KhnurAtak2());
    }
    public void ActionAttack()
    {
        Attacking?.Invoke();
    }
    public void ActionLeaveFightState()
    {
        LeaveFightState?.Invoke();
    }
    public UnityAction Boar;
    public void ActionBoar()
    {
        Boar?.Invoke();
    }
}
