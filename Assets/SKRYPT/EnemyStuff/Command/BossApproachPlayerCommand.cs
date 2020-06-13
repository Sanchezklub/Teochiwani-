using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossApproachPlayerCommand : Command
{

    private Transform boss;
    private Transform player;
    private float speed;

    public BossApproachPlayerCommand(Transform boss, Transform player, float speed)
    {
        this.boss = boss;
        this.player = player;
        this.speed = speed;
    }

    public override void StartExecution(UnityAction<Command> OnFinishCallback)
    {
        base.StartExecution(OnFinishCallback);
    }

    public override void UpdateExecution()
    {
        base.UpdateExecution();

        boss.transform.position = Vector3.MoveTowards(boss.transform.position, player.transform.position, speed);

        if(Vector3.Distance(boss.position, player.position) < 1)
        {
            FinishExecution();
        }
    }

    public override void FinishExecution()
    {
        base.FinishExecution();
    }
}
