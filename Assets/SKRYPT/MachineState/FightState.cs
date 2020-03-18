using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : BaseState<EnemyBrain>
{
    private EnemyBrain brain;
    private Animator enemyAnimator;
    
    private GameObject player;

    public override void InitState(EnemyBrain controller)
    {
        base.InitState(controller);
        this.brain=controller;

        this.enemyAnimator = controller.enemyAnimator;
        enemyAnimator.SetBool(Keys.PATROL_ANIM_KEY, false);
        player = GameObject.Find("Player");
        controller.Attacking += Attack;

    }
    public override void UpdateState()
    {
        base.UpdateState();

        float distance = Vector3.Distance(brain.transform.position, player.transform.position);

        if (distance > brain.StartFightDist)
        {
            brain.StartFollow();
        }
    }

    public void Attack()
    {

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(brain.transform.position, brain.AttackRange);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                Health player = hitColliders[i].GetComponent<Health>();
                player?.TakeDamage(brain.damage);
                break;
            }
            
            i++;
        }

    }


    public override void DeinitState(EnemyBrain controller)
    {
        brain.Attacking -= Attack;
        base. DeinitState(controller);
    }
}
