using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderFightState : BaseState<CommanderBrain>
{

    //być może trzeba będzie pozmieniać, jak będą animacje
    private CommanderBrain brain;

    private float LastSummonTime;
    public override void InitState(CommanderBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        // animacje?
        LastSummonTime = Time.time;
        Summon();
    }

    void Summon()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            GameObject.Instantiate(brain.ShieldmanPrefab, brain.SummonPoint.position, Quaternion.identity); 
        }
        else
        {
            GameObject.Instantiate(brain.SpearmanPrefab, brain.SummonPoint.position, Quaternion.identity);
        }

    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Time.time > LastSummonTime + brain.SummonWaitTime)
        {
            Summon();
            LastSummonTime = Time.time;
        }
    }

    public override void DeinitState(CommanderBrain controller)
    {
        base.DeinitState(controller);
    }


}
