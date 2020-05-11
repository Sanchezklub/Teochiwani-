using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderClimbState : BaseState<SpiderBrain>
{
    
    [SerializeField]
    private SpiderBrain brain;
    private float Target;

    public override void InitState(SpiderBrain controller)
    {
       this.brain = controller;
        brain.enemyAnimator.SetBool("isjumping", true);
        brain.SpiderCollider.isTrigger = true;
       Target = GameObject.Find("SpiderPktUp").GetComponent<Transform>().position.y;
      
    }


    public override void UpdateState()
    {
        base.UpdateState();
        MoveTowardsTarget();

    }



    void MoveTowardsTarget()
    {
        float PositionDifference = brain.transform.position.y - Target;
        if (PositionDifference <= 0)
        {
            brain.SpiderRigidbody.velocity = new Vector2(0,brain.speed*1);
            //Debug.Log("wspina");
            brain.FacingRight = false;
        }
        else if(PositionDifference <1)
        {
            brain.StartShoot();
        }
    }

    public override void DeinitState(SpiderBrain controller)
    {
        base.DeinitState(controller);
        brain.enemyAnimator.SetBool("isjumping", false);
    }




}

