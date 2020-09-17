using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EvilPlayerIdleState : BaseState<EvilPlayerBrain>
{
    private EvilPlayerBrain brain;
    public override void InitState(EvilPlayerBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Vector3.Distance(GameController.instance.DataStorage.PlayerInfo.playerPosition, brain.transform.position) < brain.AggroRange)
        {
            brain.StartFollow();
        }
    }

    public override void DeinitState(EvilPlayerBrain controller)
    {
        base.DeinitState(controller);
    }
}
