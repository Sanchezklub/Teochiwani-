using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGodsRunState : BaseState<FalseGodsBrain>
{
    private FalseGodsBrain brain;

    private float StartTime;
    public override void InitState(FalseGodsBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.TulioAnimator.SetBool("RunAround", true);
        StartTime = Time.time;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        RunAround();
        CheckTime();
    }


    void RunAround()
    {
        if (Physics2D.Raycast(brain.RaycastTransform.position, Vector2.down, 4.5f, brain.WhatIsGround) && !Physics2D.Raycast(brain.RaycastTransform.position, Vector2.right, 2f, brain.WhatIsGround))
        {

            Debug.DrawRay(brain.RaycastTransform.position, Vector2.down * 4.5f, Color.yellow);
            Debug.DrawRay(brain.RaycastTransform.position, Vector2.left * 2f, Color.yellow);
            if (brain.FacingRight == true)
            {
                brain.rb.velocity = new Vector2(1 * brain.MovementSpeed, brain.rb.velocity.y);
                //brain.MiguelRb.velocity = new Vector2(1 * brain.MovementSpeed, brain.MiguelRb.velocity.y);
            }
            else
            {
                brain.rb.velocity = new Vector2(-1 * brain.MovementSpeed, brain.rb.velocity.y);
                //brain.MiguelRb.velocity = new Vector2(-1 * brain.MovementSpeed, brain.MiguelRb.velocity.y);
            }




        }
        else
        {
            Flip();
        }
    }

    void CheckTime()
    {
        Debug.Log("FalseGods checked time");
        if (Time.time > StartTime + brain.RunTime)
        {
            StartAttack();
        }
    }

    void Flip()
    {
        brain.FacingRight = !brain.FacingRight;
        brain.transform.Rotate(new Vector2(0, 180f));
    }

    void StartAttack()
    {
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            brain.StartBall();
        }
        else
        {
            brain.StartPrayer();
        }
    }

    public override void DeinitState(FalseGodsBrain controller)
    {
        brain.TulioAnimator.SetBool("RunAround", false);
        base.DeinitState(controller);
    }
}
