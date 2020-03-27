using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoStompState : BaseState<RhinoBrain>
{
    private RhinoBrain brain;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;

    public override void InitState(RhinoBrain controller)
    {

        base.InitState(controller);
        this.brain = controller;
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        enemyRigidBody2D.velocity = new Vector2(0, 0);

    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (Input.GetKeyDown("space"))
        {
            Attack();
        }

    }

    public void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(brain.StompAttackPoint.position, brain.StompRange);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                Health player = hitColliders[i].GetComponent<Health>();
                player?.TakeDamage(brain.StompDamage);
                if(brain.FacingRight == false)
                {
                    player.GetComponent<Rigidbody2D>()?.AddForce(new Vector2(brain.HorStompKnockback, brain.VerStompKnockback));
                }
                else
                {
                    player.GetComponent<Rigidbody2D>()?.AddForce(new Vector2(brain.HorStompKnockback, brain.VerStompKnockback));
                }
                break;
            }

            i++;
        }
        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        if (distance < brain.StompDist)
        {
            brain.StartStomp();
        }
        else
        {
            brain.StartCharge();
        }

    }


    public override void DeinitState(RhinoBrain controller)
    {
        base.DeinitState(controller);
    }
}
