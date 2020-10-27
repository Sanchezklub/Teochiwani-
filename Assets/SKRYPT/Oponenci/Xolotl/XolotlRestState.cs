using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolotlRestState : BaseState<XolotlBrain>
{
    private XolotlBrain brain;
    public float currentRestTime;
    public override void InitState(XolotlBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        currentRestTime=0;
        brain.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Debug.Log("Xolotl rest");
    }
    
    public override void UpdateState()
    {
        TimeCheck();
    }

    private void TimeCheck()
    {
        currentRestTime += Time.deltaTime;
        if (currentRestTime > brain.RestTime + Time.deltaTime)
        {
            brain.StartAttackBlood();
        }
    }
    public override void DeinitState(XolotlBrain controller)
    {
        
        base.DeinitState(controller);
    }
}
