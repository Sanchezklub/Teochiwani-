using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBossAttackState : BaseState<TigerBoss>
{
    private float startTime;
    private TigerBoss controller;

    public override void InitState(TigerBoss controller)
    {
        base.InitState(controller);
        this.controller = controller;
        controller.BossAnimator.SetTrigger(controller.ATTACK_KEY);
        startTime = Time.time;

        controller.OnAnimationAttackedCallback += LaunchAttack;        
    }

    public void LaunchAttack()
    {
        Collider2D[] colls = Physics2D.OverlapBoxAll(controller.targetPosition, controller.AttackSize, 0f);

        foreach(var col in colls)
        {
            TigerBossCage cage = col.transform.GetComponent<TigerBossCage>();
            if(cage != null)
            {
                cage.OpenCage(controller);
            }
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(startTime + controller.AttackDuration < Time.time)
        {
            controller.StartFollowState();
        }
    }

    public override void DeinitState(TigerBoss controller)
    {
        controller.OnAnimationAttackedCallback -= LaunchAttack;
        base.DeinitState(controller);
    }
}
