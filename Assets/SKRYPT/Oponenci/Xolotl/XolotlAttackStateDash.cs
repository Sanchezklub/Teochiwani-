using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolotlAttackStateDash : BaseState<XolotlBrain>
{
    private XolotlBrain brain;
    public override void InitState(XolotlBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
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
