using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitCommand : Command
{
    private float duration;
    private float startTime;

    public WaitCommand(float duration)
    {
        this.duration = duration;
    }

    public override void StartExecution(UnityAction<Command> OnFinishCallback)
    {
        base.StartExecution(OnFinishCallback);
        this.startTime = Time.time;
    }

    public override void UpdateExecution()
    {
        base.UpdateExecution();

        if (startTime + duration < Time.time)
            FinishExecution();

    }

    public override void FinishExecution()
    {
        base.FinishExecution();
    }

}
