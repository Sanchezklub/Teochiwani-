using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XolotlBrain : BaseBrain<XolotlBrain>
{
    public float RestTime;
    public float TimeBetweenDash;
    public float DashSpeed;

    public GameObject Blood;

    public Animator enemyAnimator;

    public BoxCollider2D boxCollider2D;

    public Rigidbody2D rb2d;

    
    public UnityAction Attacking;
    public UnityAction LeaveFightState;

    private void Start()
    {
        
        StartRest();

    }
    private void Update()
    {
        UpdateChildState();
    }

    public override void ChangeState(BaseState<XolotlBrain> newState)
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

    public void StartAttackBlood()
    {
        ChangeState(new XolotlAttackStateBlood());
    }

    public void StartAttackDash()
    {
        //enemyToFollow = objectToFollow;
        ChangeState(new XolotlAttackStateDash());
    }
    public void StartRest()
    {
        ChangeState(new XolotlRestState());
    }
    
}
