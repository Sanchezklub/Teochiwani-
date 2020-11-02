using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerAttackState : BaseState<EvilPlayerBrain>
{
    private EvilPlayerBrain brain;
    private Vector3 tempTarget;
    public override void InitState(EvilPlayerBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.animator.SetFloat("Speed", 0);
        if (brain.combat.currentWeapon.AttackAnimationType != BaseWeapon.AnimationType.IsAttackingThrow)
        {
            brain.combat.Attack();
        }
        else
        {
            brain.animator.SetBool("IsAttacking", true);
            brain.animator.SetBool("IsAttackingThrow", true);
            brain.evilSpearAttack += ThrowSpear;
            tempTarget = GameController.instance.DataStorage.PlayerInfo.playerPosition;
        }
    }
    void ThrowSpear()
    {
        GameObject projectile = GameObject.Instantiate(brain.SpearPrefab, brain.throwPosition.position, Quaternion.identity);
        projectile.GetComponent<Bullet>().target = tempTarget;
        brain.animator.SetBool("IsAttacking", true);
        brain.animator.SetBool("IsAttackingThrow", true);
        brain.StartFollow();
    }
}
