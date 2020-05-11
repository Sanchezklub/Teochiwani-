using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStunState : BaseState<SpiderBrain>
{
    private Rigidbody2D enemyrigidbody;
    private SpiderBrain brain;
    private GameObject player;
    private float CurrentTimeStunned;
    public override void InitState(SpiderBrain controller)
    {

        base.InitState(controller);
        this.brain = controller;
        brain.SpiderCollider.isTrigger = false;
        enemyrigidbody = brain.GetComponent<Rigidbody2D>();
        enemyrigidbody.velocity = new Vector2(0, 0);
    }
    
    public override void UpdateState()
    {
        base.UpdateState();
        CurrentTimeStunned += Time.deltaTime;
        if (CurrentTimeStunned > brain.StunTime)
        {
            StopBeingStunned();
        }
    }
    void StopBeingStunned()
    {
        brain.StartWalk();
    }
    public override void DeinitState(SpiderBrain controller)
    {
        base.DeinitState(controller);
    }
}
