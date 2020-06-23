using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGodsIdleState : BaseState<FalseGodsBrain>
{
    private FalseGodsBrain brain;

    public override void InitState(FalseGodsBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if ((Vector3.Distance(brain.transform.position, GameController.instance.DataStorage.PlayerInfo.playerPosition)) < brain.AggroRange)
        {
            brain.StartRun();
        }
    }
}
