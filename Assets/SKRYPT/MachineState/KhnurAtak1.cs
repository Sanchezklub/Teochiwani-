using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhnurAtak1 : BaseState<KhnurBrain>
{
    private Collider2D Shield;
    private KhnurBrain brain;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;

    public override void InitState(KhnurBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.enemyAnimator.SetBool("Atak1", true);
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        enemyRigidBody2D.velocity = new Vector2(0, 0);

        brain.Attacking += Attack;
        brain.LeaveFightState += AttemptLeavingFightState;

    }
    public override void UpdateState()
    {
        base.UpdateState();

    }

    public void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(brain.AttackPoint.position, brain.AttackRange);
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


    public override void DeinitState(KhnurBrain controller)
    {
        brain.Attacking -= Attack;
        brain.LeaveFightState -= AttemptLeavingFightState;
        brain.enemyAnimator.SetBool("Atak1", false);
        base.DeinitState(controller);
    }

    public void AttemptLeavingFightState()
    {
        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        Debug.Log("Attempted to leave FightState. Distance was:" + distance);
        int rand = Random.Range(1, 3);
        if (rand==1)
        {
            Debug.Log("left fightstate");
            brain.StartAtak1();
        }
        else 
        {
            Debug.Log("left fightstate");
            brain.StartAtak2();
        }
    }
}

