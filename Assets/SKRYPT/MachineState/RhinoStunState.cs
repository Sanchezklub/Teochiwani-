using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoStunState : BaseState<RhinoBrain>
{
    private Rigidbody2D enemyrigidbody;
    private RhinoBrain brain;
    private GameObject player;
    private float CurrentTimeStunned;
    public override void InitState(RhinoBrain controller)
    {

        base.InitState(controller);
        this.brain = controller;
        player = GameObject.Find("Player");
        brain.enemyAnimator.SetBool("Idle", true);
        brain.enemyAnimator.SetBool("Charge", false);
        brain.enemyAnimator.SetBool("Attack", false);
        enemyrigidbody = brain.GetComponent<Rigidbody2D>();
        enemyrigidbody.velocity =new Vector2 (0, 0);
        brain.RhinoCollider.SetActive(true);
        MoveBack();
    }
    public void MoveBack()
    {
        if (brain.FacingRight)
        {
            if (Physics2D.Raycast(brain.raycastTransform.position, Vector2.right, 0.1f, brain.WhatIsGround)){
                brain.transform.Translate(new Vector3(0.15f, 0, 0));
            }
        }
        else if (Physics2D.Raycast(brain.raycastTransform.position, Vector2.left, 0.1f, brain.WhatIsGround)){
            brain.transform.Translate(new Vector3(-0.15f, 0, 0));
            }
    }
    public override void UpdateState()
    {
        float distance = Vector3.Distance(player.transform.position, brain.transform.position);
        base.UpdateState();
        CurrentTimeStunned += Time.deltaTime;
        if (CurrentTimeStunned > brain.StunTime)
        {
            StopBeingStunned();
        }
    }
    void StopBeingStunned()
    {
        float distance = Vector3.Distance(player.transform.position, brain.transform.position);
        Debug.Log("Done waiting");
        if (distance > brain.StompDist)
        {
            brain.StartCharge();
        }
        else if (distance < brain.StompDist)
        {
            brain.StartCharge();
        }
    }
    public override void DeinitState(RhinoBrain controller)
    {
        base.DeinitState(controller);
        brain.RhinoCollider.SetActive(false);
    }
}
