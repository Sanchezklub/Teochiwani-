using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : BaseState<DragonBrain>
{
    private DragonBrain brain;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    float PositionDifference;
    GameObject fl;

    public override void InitState(DragonBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        enemyRigidBody2D.velocity = new Vector2(0, 0);
        brain.enemyAnimator.SetBool("Patrol", false);
        brain.enemyAnimator.SetBool("Attack", true);
        brain.Attacking += Attack;
        brain.LeaveFightState += AttemptLeavingFightState;

    }
    public override void UpdateState()
    {
        base.UpdateState();

    }

    public void Attack()
    {
        fl = GameObject.Instantiate(brain.Flame,brain.Firepoint.position,Quaternion.identity);
        fl.transform.parent = brain.Firepoint;
    }

    public void AttemptLeavingFightState()
    {
        GameObject.Destroy(fl);
        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        //Debug.Log("Attempted to leave FightState. Distance was:" + distance);
        if (distance > brain.StartAttackDist)
        {
            //Debug.Log("left fightstate");
            brain.StartEscape();
        }
        else
        {
            brain.StartAttack();

        }
    }
    void MoveTowardsPlayer()
    {
        PositionDifference = brain.transform.position.x - player.transform.position.x;
        if (PositionDifference >= 0)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
            enemyRigidBody2D.velocity = new Vector2(-1 * brain.speed, enemyRigidBody2D.velocity.y);
            brain.FacingRight = false;
        }
        else if (PositionDifference <= 0)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            enemyRigidBody2D.velocity = new Vector2(1 * brain.speed, enemyRigidBody2D.velocity.y);
            brain.FacingRight = true;
        }

    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
    }
    
    public override void DeinitState(DragonBrain controller)
    {
        brain.Attacking -= Attack;
        brain.LeaveFightState -= AttemptLeavingFightState;
        base.DeinitState(controller);
        brain.enemyAnimator.SetBool("Patrol", true);
        brain.enemyAnimator.SetBool("Attack", false);
    }
}
