using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkolopendraCommandInvoker : CommandInvoker
{
    // Start is called before the first frame update

    public float baseSpeed;
    public float maxSpeedPercentage;

    public float baseMinDigWaitTime;
    public float maxMinDigWaitTimePercentage;

    public float baseMaxDigWaitTime;
    public float maxMaxDigWaitTimePercentage;

    public float Speed;
    public float MinDigWaitTime;
    public float MaxDigWaitTime;

    public LayerMask WhatIsGround;

    public Rigidbody2D rb;

    public Transform Raycast;

    public float UndergroundWaitTime;

    public EnemyHealth Health;

    void CalculateBuffs()
    {
        float BaseValue = (1f - Mathf.InverseLerp(0f, Health.MaxHealth, Health.currentHealth));

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
        Health = GetComponent<EnemyHealth>();
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
        AddCommand(new SkolopendraDigDownCommand());
        AddCommand(new SkolopendraWaitCommand(UndergroundWaitTime));
        AddCommand(new SkolopendraDigUpCommand());

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
