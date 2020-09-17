using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerAttackState : BaseState<EvilPlayerBrain>
{
    private EvilPlayerBrain brain;
    public override void InitState(EvilPlayerBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.combat.Attack();
    }
}
