using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBossFollowState : BaseState<TigerBoss>
{
    private TigerBoss controller;

    public override void InitState(TigerBoss controller)
    {
        base.InitState(controller);
        this.controller = controller;
    }

    public override void UpdateState()
    {
        //base.UpdateState();
        if (Vector2.Distance(controller.transform.position, controller.targetPosition) < controller.AttackDistance)
        {
            controller.StartAttackState();
            return;
        }

        var move = (controller.transform.position - controller.targetPosition).normalized;
        if(move.x > 0)
        {
            controller.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else
        {
            controller.transform.rotation = Quaternion.identity;
        }


        var targetPos = controller.targetPosition;
        targetPos.y = 0f;
        controller.transform.position = Vector2.MoveTowards(controller.transform.position, targetPos, controller.MovementSpeed);

        
    }

    public override void DeinitState(TigerBoss controller)
    {
        base.DeinitState(controller);
    }
}
