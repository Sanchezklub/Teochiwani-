using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearmanShotState : BaseState<SpearmanBrain>
{
    private SpearmanBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;

     public override void InitState(SpearmanBrain controller)
    {
        base.InitState(controller);
       // var renderer = controller.gameObject.GetComponent<MeshRenderer>();
      //  renderer.material.color = Color.green;
        this.brain = controller;

        this.enemyAnimator = controller.enemyAnimator;
        enemyAnimator?.SetBool("IsAttacking",true);
        player = GameObject.Find("Player");
        controller.Attacking += rzut;
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        /*if (brain.FacingRight == false)
        {
            brain.transform.Rotate(new Vector2(0f, 180f));
        }*/
    }
    public void rzut()
    {
        MoveTowardsPlayer();
        if (brain.FacingRight == true)
        {
            GameObject projectile = GameObject.Instantiate(brain.Projectile, brain.FirePoint.position, Quaternion.Euler(new Vector3 (0,0,13.762f))) as GameObject;

        }
        else
        {
            GameObject projectile = GameObject.Instantiate(brain.Projectile, brain.FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 166.238f))) as GameObject;
        }
        enemyAnimator.SetTrigger("Reload");
        if(Vector3.Distance(brain.transform.position,player.transform.position)>brain.StopFollowDist)
        {
            brain.StartPatrol();
        }
    }
    void MoveTowardsPlayer()
    {
        float PositionDifference = brain.transform.position.x - player.transform.position.x;
        if(PositionDifference >= 0)
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
    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
    }
    public override void DeinitState(SpearmanBrain controller)
    {
        brain.Attacking-=rzut;
        base.DeinitState(controller);
        enemyAnimator.SetBool("IsAttacking",false);
    }
}
