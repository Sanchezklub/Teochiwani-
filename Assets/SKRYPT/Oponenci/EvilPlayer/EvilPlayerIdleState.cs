﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EvilPlayerIdleState : BaseState<EvilPlayerBrain>
{
    private EvilPlayerBrain brain;
    public override void InitState(EvilPlayerBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.animator.SetBool("Idle", true);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        float dist = Vector3.Distance(GameController.instance.DataStorage.PlayerInfo.playerPosition, brain.transform.position);
        if (dist < brain.AggroRange && WeaponTypeCheck())
        {
            brain.StartFollow();
        }
    }

    public override void DeinitState(EvilPlayerBrain controller)
    {
        brain.animator.SetBool("Idle", false);
        base.DeinitState(controller);
    }

    bool WeaponTypeCheck()
    {
        if (brain.combat.currentWeapon == null)
        {
            return false;
        }

        else if (brain.combat.currentWeapon.AttackAnimationType == BaseWeapon.AnimationType.IsAttackingRanged || 
            brain.combat.currentWeapon.AttackAnimationType == BaseWeapon.AnimationType.IsAttackingShoot ||
            brain.combat.currentWeapon.AttackAnimationType == BaseWeapon.AnimationType.IsAttackingThrow)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
