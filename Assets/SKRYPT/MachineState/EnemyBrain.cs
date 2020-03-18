using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBrain : BaseBrain<EnemyBrain>
{
    public Animator enemyAnimator;
    public Transform raycastTransform;
    [SerializeField] public LayerMask WhatIsGround;


    public UnityAction Attacking;

    public float MaxHealth;
    public float CurrentHealth;
    public float damage;
    public float speed;
    public float StartFollowDist;
    public float StopFollowDist;
    public float StartFightDist;
    public float AttackRange;
    public GameObject FloatingTextPrefab;

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

        Debug.Log(currentState);
    }

    public void DealDamage()
    {
        Attacking?.Invoke();
    }


    public override void ChangeState(BaseState<EnemyBrain> newState)
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
        ChangeState (new PatrolState());
    }

    public void StartFollow()
    {
        ChangeState(new FollowState());
    }

    public virtual void ShowFloatingText(float damage)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = damage.ToString();
    }

    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        ShowFloatingText(damage);
        if (CurrentHealth <= 0)
        {
            Die();
        }


    }

    public virtual void Die()
    {
        if (enemyAnimator)
        { Destroy(gameObject, 3f); }
        else
        {
            Destroy(gameObject);
        }
    }
}
