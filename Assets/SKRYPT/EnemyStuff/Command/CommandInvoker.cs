using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    public Queue<Command> commandQueue = new Queue<Command>();

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        if (commandQueue.Count > 0)
            commandQueue?.Peek().UpdateExecution();
    }

    public virtual void AddCommand(Command command)
    {
        commandQueue.Enqueue(command);
    }

    public virtual void StartExecution()
    {
        commandQueue.Peek().StartExecution(OnCommandFinished);
    }

    public virtual void MakeAttackInstruction()
    {
        AddCommand(new LogCommand("D_Started"));
        AddCommand(new WaitCommand(1));
        AddCommand(new LogCommand("D_MidTime"));
        AddCommand(new WaitCommand(1));
        AddCommand(new LogCommand("D_EndTime"));
        AddCommand(new WaitCommand(1));

        StartExecution();
    }

    public virtual void MakeAttackInstruction2()
    {
        AddCommand(new WaitCommand(1));
        AddCommand(new LogCommand("D_EndTime"));
        AddCommand(new WaitCommand(1));

        StartExecution();
    }

    public virtual void OnCommandFinished(Command command)
    {
        commandQueue.Dequeue();

        if(commandQueue.Count > 0)
        {
            StartExecution();
        } else
        {
            MakeAttackInstruction2();
        }
    }
}
