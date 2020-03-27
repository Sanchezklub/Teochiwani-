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
        enemyrigidbody = brain.GetComponent<Rigidbody2D>();
        enemyrigidbody.velocity =new Vector2 (0, 0);
        brain.RhinoCollider.SetActive(true);

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
        Debug.Log("Done waiting");
        if (Vector3.Distance(player.transform.position, brain.transform.position) < brain.StompDist)
        {
            brain.StartStomp();
        }
        else
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
