using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhnurAtak1 : BaseState<KhnurBrain>
{
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
        brain.Attacking += StartWalking;
        brain.LeaveFightState += AttemptLeavingFightState;
        FacePlayer();

    }
    public override void UpdateState()
    {
        base.UpdateState();

    }
    public void FacePlayer()
    {
        float PositionDifference = brain.transform.position.x - player.transform.position.x;
        if (PositionDifference >= 0)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
            brain.FacingRight = false;
        }
        else if (PositionDifference <= 0)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            brain.FacingRight = true;
        }
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
    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
    public void StartWalking()
    {
        if (brain.FacingRight == true)
        {
            enemyRigidBody2D.velocity = new Vector2(brain.speed, enemyRigidBody2D.velocity.y);
        }
        else
        {
            enemyRigidBody2D.velocity = new Vector2(-brain.speed, enemyRigidBody2D.velocity.y);
        }
        brain.Attacking -= StartWalking;
    }


    public override void DeinitState(KhnurBrain controller)
    {
        brain.Attacking -= Attack;
        brain.LeaveFightState -= AttemptLeavingFightState;
        brain.enemyAnimator.SetBool("Atak1", false);
        enemyRigidBody2D.velocity = Vector2.zero;
        base.DeinitState(controller);
    }

    public void AttemptLeavingFightState()
    {
        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        int rand = Random.Range(1, 3);
        if (rand == 1 || brain.SummonCount >= 3)
        {
            brain.SummonCount = 0;
            Debug.Log("left fightstate");
            brain.StartAtak1();
        }
        else 
        {
            brain.SummonCount++;
            Debug.Log("left fightstate");
            brain.StartAtak2();
        }
    }
}

