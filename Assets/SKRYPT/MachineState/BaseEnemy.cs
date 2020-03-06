using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : BaseBrain<BaseEnemy>
{
    public Animator enemyAnimator;
    public Transform raycastTransform;

    
    public UnityAction OnDamageTaken;

    public float health;
    public float damage;
    public float speed;

    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartFight();
        }
    }

    public void TakeDamage()
    {
        OnDamageTaken?.Invoke();
    }


    public override void ChangeState(BaseState<BaseEnemy> newState)
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

    public void StartFight()
    {
        ChangeState(new FightState());
    }

    public void StartPatrol()
    {
        //enemyToFollow = objectToFollow;
        ChangeState (new FollowState());
    }
}
