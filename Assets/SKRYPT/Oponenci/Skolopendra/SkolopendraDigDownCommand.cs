using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkolopendraDigDownCommand : Command
{
    private Vector2 TempPosition;
    private Rigidbody2D rb;


    public SkolopendraDigDownCommand(Vector2 TempPosition, Rigidbody2D rb)
    {
        this.TempPosition = TempPosition;
        this.rb = rb;
    }

    public override void StartExecution(UnityAction<Command> OnFinishCallback)
    {
        base.StartExecution(OnFinishCallback);
        rb.transform.position = TempPosition;
        FinishExecution();
    }
}
