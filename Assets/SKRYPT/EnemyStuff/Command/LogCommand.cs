using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogCommand : Command
{
    private string mess;

    public LogCommand(string message)
    {
        this.mess = message;
    }

    public override void StartExecution(UnityAction<Command> OnFinishCallback)
    {
        base.StartExecution(OnFinishCallback);

        Debug.Log(mess);
        FinishExecution();
    }

    public override void UpdateExecution()
    {
        base.UpdateExecution();
    }

    public override void FinishExecution()
    {
        base.FinishExecution();
    }
}
