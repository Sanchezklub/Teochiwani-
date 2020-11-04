using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EvilPlayerAttackState : BaseState<EvilPlayerBrain>
{
    private EvilPlayerBrain brain;
    private Vector3 tempTarget;
    public override void InitState(EvilPlayerBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.animator.SetFloat("Speed", 0);
        Debug.Log("Animator variable speed should've been set to 0");
        brain.combat.Attack();
    }

    public override void UpdateState()
    {
        brain.animator.SetFloat("Speed", 0);
        if (!brain.combat.isAttacking)
        {
            brain.combat.Attack();
        }
    }
    public override void DeinitState(EvilPlayerBrain controller)
    {
        base.DeinitState(controller);
    }

    /*else
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
    */
}
