using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalkState : BaseState<SpiderBrain>
{
    [SerializeField]
    private SpiderBrain brain;
    private float Target;

    public override void InitState(SpiderBrain controller)
    {
        this.brain = controller;
        brain.SpiderCollider.isTrigger = false;
        if (brain.RightSide == true) 
        {
            Target = GameObject.Find("SpiderPktL").GetComponent<Transform>().position.x;
        }
        else
        {
            Target = GameObject.Find("SpiderPktR").GetComponent<Transform>().position.x;
        }
    }


    public override void UpdateState()
    {
        base.UpdateState();
        MoveTowardsTarget();

    }



    void MoveTowardsTarget()
    {
       float PositionDifference = brain.transform.position.x - Target;
        if (PositionDifference >= 0.3)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
            brain.SpiderRigidbody.velocity = new Vector2(-1 * brain.speed, brain.SpiderRigidbody.velocity.y);
            brain.FacingRight = false;
        }
        else if (PositionDifference <= -0.3)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            brain.SpiderRigidbody.velocity = new Vector2(1 * brain.speed, brain.SpiderRigidbody.velocity.y);
            brain.FacingRight = true;
        }
        else
        {
            brain.RightSide = !brain.RightSide;
            brain.StartClimb();
        }

    }


    void Flip()
    {

    }






}


