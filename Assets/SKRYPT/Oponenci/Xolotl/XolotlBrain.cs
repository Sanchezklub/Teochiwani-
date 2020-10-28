using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XolotlBrain : BaseBrain<XolotlBrain>
{
    public bool FacingRight;
    public float TimeAfterBloodRise;
    public float TimeAfterBloodLowers;
    public float TimeAfterBloodEnds;
    public float RestTime;
    public float DashSpeed;
    public float TimeBetweenDash;
    public float AnimationDuration;
    public float RisingVelocity;
    public float BloodDamage;
    public float DashDamage;

    public Animator animator;

    public BoxCollider2D boxCollider2D;

    public Rigidbody2D rb2d;
    public GameObject Ps;
    public SpriteRenderer sr;
    public GameObject Blood;
    public GameObject XolotlHitbox;
    public GameObject[] Podest;

    public UnityAction Attacking;
    public UnityAction LeaveFightState;

    private void Start()
    {
        
        Podest = GameObject.FindGameObjectsWithTag("XolotlPodest");

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
