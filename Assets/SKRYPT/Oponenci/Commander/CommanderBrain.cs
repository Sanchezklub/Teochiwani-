using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderBrain : BaseBrain<CommanderBrain>
{

    public Rigidbody2D rb;
    public Transform RaycastTransform;
    public Transform SummonPoint;
    
    public float Speed;
    public float SummonWaitTime;
    public float BrainStartFightDist;

    public bool FacingRight;

    public LayerMask WhatIsGround;

    public GameObject ShieldmanPrefab;
    public GameObject SpearmanPrefab;
    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();

        Debug.Log(currentState + "Shieldman State is");
    }

    public override void ChangeState(BaseState<CommanderBrain> newState)
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
        ChangeState(new CommanderPatrolState());
    }

    public void StartFight()
    {
        //enemyToFollow = objectToFollow;
        ChangeState(new CommanderFightState());
    }
}
