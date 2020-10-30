using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBossDamageState : BaseState<TigerBoss>
{
    public TigerTemplateBoss tigerToThrow;
    private TigerBoss controller;

    public override void InitState(TigerBoss controller)
    {
        base.InitState(controller);

        controller.BossAnimator.SetTrigger(controller.DAMAGE_KEY);
        controller.OnAnimationThrowCallback += ThrowTiger;
        controller.OnAnimationDamageCompleted += ExitDamageState;
        this.controller = controller;
    }

    public void ThrowTiger()
    {
        tigerToThrow.transform.parent = null;
        tigerToThrow.tigerRb.AddForce(Vector2.up * 1000f, ForceMode2D.Impulse);
        tigerToThrow.velocityCheck = true;
    }

    public void ExitDamageState()
    {
        controller.StartFollowState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void DeinitState(TigerBoss controller)
    {
        controller.OnAnimationThrowCallback -= ThrowTiger;
        controller.OnAnimationDamageCompleted -= ExitDamageState;
        base.DeinitState(controller);
    }
}
