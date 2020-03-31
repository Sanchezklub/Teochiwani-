using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoIdleState : BaseState <RhinoBrain>
{
    private RhinoBrain brain;
    public override void InitState(RhinoBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.enemyAnimator.SetBool("Idle", true);
    }
    public override void UpdateState()
    {
        float distance = Vector3.Distance(brain.transform.position, GameController.instance.DataStorage.PlayerInfo.playerPosition);
        if (brain.AggroDist < distance)
        {
            brain.StartCharge();
        }
    }

    public override void DeinitState(RhinoBrain controller)
    {
        base.DeinitState(controller);
    }
}
