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
        Debug.Log("State updated");
        float dist = Vector3.Distance(GameController.instance.DataStorage.PlayerInfo.playerPosition, brain.transform.position);
        Debug.Log("Distance was" + dist);
        if (dist < brain.AggroRange)
        {
            brain.StartFollow();
        }
    }

    public override void DeinitState(EvilPlayerBrain controller)
    {
        base.DeinitState(controller);
    }
}
