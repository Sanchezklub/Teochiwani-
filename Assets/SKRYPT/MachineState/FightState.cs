using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : BaseState<BaseEnemy>
{
    private BaseEnemy brain;
    private Animator enemyAnimator;
    
    private GameObject player;
    private float attackTime;
    private float attackDelay = 3f;

    public override void InitState(BaseEnemy controller)
    {
        base.InitState(controller);
      //  var renderer = controller.gameObject.GetComponent<MeshRenderer>();
     //   renderer.material.color = Color.red;
        this.brain=controller;

        this.enemyAnimator = controller.enemyAnimator;
        enemyAnimator.SetBool(Keys.PATROL_ANIM_KEY, false);
        player = GameObject.Find("Player");
        controller.OnDamageTaken += Attack;

    }
    public override void UpdateState()
    {
        base.UpdateState();

        float distance = Vector3.Distance(brain.transform.position, player.transform.position);

        if (distance > 5f)
        {
            brain.StartPatrol();
        }
    }

    public void Attack()
    {

        Collider[] hitColliders = Physics.OverlapSphere(brain.transform.position, 15f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            Health player = hitColliders[i].GetComponent<Health>();
            player?.TakeDamage(brain.damage);
            i++;
        }
    }


    public override void DeinitState(BaseEnemy controller)
    {
        brain.OnDamageTaken -= Attack;
        base. DeinitState(controller);
    }
}
