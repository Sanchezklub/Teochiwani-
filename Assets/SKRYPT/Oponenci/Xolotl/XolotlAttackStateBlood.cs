using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolotlAttackStateBlood : BaseState<XolotlBrain>
{
    private XolotlBrain brain;
    public override void InitState(XolotlBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        Debug.Log("Xolotl Blood");
        brain.StartAttackDash();
    }
    public override void UpdateState()
    {
        base.UpdateState();

    }
    public override void DeinitState(XolotlBrain controller)
    {
        
        base.DeinitState(controller);
    }
}
