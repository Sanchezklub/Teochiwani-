using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoStompState : BaseState<RhinoBrain>
{
    private RhinoBrain brain;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    private int AttackCount;
    public override void InitState(RhinoBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.enemyAnimator.SetBool("Attack", true);
        brain.enemyAnimator.SetBool("Charge", false);
        brain.enemyAnimator.SetBool("Idle", false);
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        enemyRigidBody2D.velocity = new Vector2(0, 0);
        FacePlayer();

        brain.Stomp += Attack;

    }

    public void FacePlayer()
    {
        if (brain.FacingRight && player.transform.position.x < brain.transform.position.x)
        {
            Flip();
        }
        else if (!brain.FacingRight && player.transform.position.x > brain.transform.position.x)
        {
            Flip();
        }
    }
    public override void UpdateState()
    {
        base.UpdateState();

    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
        Debug.Log("rhino flipped");
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
                    player.GetComponent<Rigidbody2D>()?.AddForce(new Vector2(-brain.HorStompKnockback, brain.VerStompKnockback));
                }
                break;
            }

            i++;
        }
        AttackCount += 1;
        if (AttackCount % 4 == 0)
        {
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

    }


    public override void DeinitState(RhinoBrain controller)
    {
        brain.Stomp -= Attack;
        base.DeinitState(controller);

    }
}
