using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkolopendraCommandInvoker : CommandInvoker
{
    // Start is called before the first frame update

    public float damage;

    public float baseSpeed;
    public float maxSpeedPercentage;

    public float baseMinDigWaitTime;
    public float maxMinDigWaitTimePercentage;

    public float baseMaxDigWaitTime;
    public float maxMaxDigWaitTimePercentage;

    public float Speed;
    public float MinDigWaitTime;
    public float MaxDigWaitTime;

    public Vector2 TempPosition;

    public LayerMask WhatIsGround;

    public Rigidbody2D rb;

    public Transform Raycast;

    public Transform SkolopendraPointL;
    public Transform SkolopendraPointR;

    public float MinX;
    public float MaxX;
    public float Y;

    public float UndergroundWaitTime;

    public SkolopendraHealth Health;

    void CalculateBuffs()
    {
        float BaseValue = Mathf.InverseLerp(0f, Health.MaxHealth, Health.currentHealth);

        float SpeedValue = BaseValue * (maxSpeedPercentage / 100);
        Speed = baseSpeed + (baseSpeed * SpeedValue);

        float MinDigWaitTimeValue = BaseValue * (maxMinDigWaitTimePercentage / 100);
        MinDigWaitTime = baseMinDigWaitTime + (baseMinDigWaitTime * MinDigWaitTimeValue);

        float MaxDigWaitTimeValue = BaseValue * (maxMaxDigWaitTimePercentage / 100);
        MaxDigWaitTime = baseMaxDigWaitTime + (baseMaxDigWaitTime * MaxDigWaitTimeValue);
    }


    protected override void Start()
    {
        base.Start();
        Health = GetComponent<SkolopendraHealth>();
        MakeSkolopendraInstruction();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void MakeSkolopendraInstruction()
    {
        CalculateBuffs();

        AddCommand(new SkolopendraMoveCommand(Speed, Raycast, MinDigWaitTime,MaxDigWaitTime, WhatIsGround, rb));
        AddCommand(new SkolopendraDigDownCommand(TempPosition, rb));
        AddCommand(new SkolopendraWaitCommand(UndergroundWaitTime));
        AddCommand(new SkolopendraDigUpCommand(MinX, MaxX, Y, rb));

        StartExecution();
    }

    public override void OnCommandFinished(Command command)
    {
        commandQueue.Dequeue();
        if (commandQueue.Count > 0)
        {
            StartExecution();
        }
        else
        {
            MakeSkolopendraInstruction();
        }
    }
}
