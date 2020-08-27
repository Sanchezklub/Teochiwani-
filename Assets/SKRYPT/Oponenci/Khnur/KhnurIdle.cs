using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhnurIdle : BaseState<KhnurBrain>
{
    private KhnurBrain brain;
    public override void InitState(KhnurBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Vector3.Distance(brain.transform.position, GameController.instance.DataStorage.PlayerInfo.playerPosition) < brain.AggroRange)
        {
            brain.StartAtak();
        }
    }

    public override void DeinitState(KhnurBrain controller)
    {
        base.DeinitState(controller);
    }
}
