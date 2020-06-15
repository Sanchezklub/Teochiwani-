using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkolopendraDigUpCommand : Command
{
    private float MinX;
    private float MaxX;
    private float Y;
    private Rigidbody2D rb;
    public SkolopendraDigUpCommand(float MinX, float MaxX, float Y, Rigidbody2D rb)
    {
        this.MinX = MinX;
        this.MaxX = MaxX;
        this.Y = Y;
        this.rb = rb;
    }

    public override void StartExecution(UnityAction<Command> OnFinishCallback)
    {
        base.StartExecution(OnFinishCallback);
        float X = Random.Range(MinX, MaxX);
        rb.position = new Vector2(X, Y);
        FinishExecution();
    }
}
