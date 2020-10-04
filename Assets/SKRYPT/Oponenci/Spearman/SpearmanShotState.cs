using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearmanShotState : BaseState<SpearmanBrain>
{
    private SpearmanBrain brain;
    private Animator enemyAnimator;
    //Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    private Vector3 tempTarget;
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
        controller.Attacking += ShortRangeDamage;
        controller.FacePlayerAction += FacePlayer;
        /*if (brain.FacingRight == false)
        {
            brain.transform.Rotate(new Vector2(0f, 180f));
        }*/
    }
    public void rzut()
    {
        if (brain.FacingRight == true)
        {
            GameObject projectile = GameObject.Instantiate(brain.Projectile, brain.FirePoint.position, Quaternion.Euler(new Vector3 (0,0,13.762f))) as GameObject;
            projectile.GetComponent<Bullet>().target = tempTarget;
        }
        else
        {
            GameObject projectile = GameObject.Instantiate(brain.Projectile, brain.FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 166.238f))) as GameObject;
            projectile.GetComponent<Bullet>().target = tempTarget;
        }
        enemyAnimator.SetTrigger("Reload");
        if(Vector3.Distance(brain.transform.position,player.transform.position)>brain.StopFollowDist)
        {
            brain.StartPatrol();
        }
    }

    public void ShortRangeDamage()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(brain.FirePoint.position, brain.MeleeDamageRange);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].tag == "Player")
            {
                Health player = hitColliders[i].GetComponent<Health>();
                player?.TakeDamage(brain.damage, brain.gameObject);
                break;
            }

            i++;
        }
    }
    public void FacePlayer()
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
        else if (PositionDifference < 0)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            brain.FacingRight = true;
        }
        SetTarget();
    }

    public void SetTarget()
    {
        tempTarget = GameController.instance.DataStorage.PlayerInfo.playerPosition;
    }
    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
    }
    public override void DeinitState(SpearmanBrain controller)
    {
        brain.Attacking-=rzut;
        controller.Attacking -= ShortRangeDamage;
        controller.FacePlayerAction -= FacePlayer;
        base.DeinitState(controller);
        enemyAnimator.SetBool("IsAttacking",false);
    }
}
