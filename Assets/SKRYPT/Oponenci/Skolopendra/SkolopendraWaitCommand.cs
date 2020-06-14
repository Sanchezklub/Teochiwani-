using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkolopendraWaitCommand : Command
{
    private float UndergroundWaitTime;
    private float StartTime;

    public SkolopendraWaitCommand(float UndergroundWaitTime)
    {
        this.UndergroundWaitTime = UndergroundWaitTime;
    }

    public override void StartExecution(UnityAction<Command> OnFinishCallback)
    {
        base.StartExecution(OnFinishCallback);
        StartTime = Time.time;
    }

    public override void UpdateExecution()
    {
        base.UpdateExecution();
        if (Time.time > StartTime + UndergroundWaitTime)
        {
            FinishExecution();
        }
    }
}
