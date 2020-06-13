using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Command
{
    public UnityAction<Command> OnCommandCompleted;

    public virtual void StartExecution(UnityAction<Command> OnFinishCallback)
    {
        OnCommandCompleted += OnFinishCallback;
    }

    public virtual void UpdateExecution()
    {

    }

    public virtual void FinishExecution()
    {
        OnCommandCompleted?.Invoke(this);
        OnCommandCompleted = null;
    }

}
