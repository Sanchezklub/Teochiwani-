using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderPatrolState : BaseState<CommanderBrain>
{

    private CommanderBrain brain;
    public override void InitState(CommanderBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        //animacje
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float distance = Vector3.Distance(brain.transform.position, GameController.instance.DataStorage.PlayerInfo.playerPosition);

        if (distance < brain.BrainStartFightDist)
        {
            brain.StartFight();
        }


        //RaycastHit2D hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics2D.Raycast(brain.RaycastTransform.position, Vector2.down, 2f, brain.WhatIsGround) && !Physics2D.Raycast(brain.RaycastTransform.position, Vector2.right, 2f, brain.WhatIsGround))
        {

            //Debug.DrawRay(brain.raycastTransform.position, Vector2.down * hit.distance, Color.yellow);

            //Debug.Log("Did Hit");
            if (brain.FacingRight == true)
            {
                brain.rb.velocity = new Vector2(1 * brain.Speed, brain.rb.velocity.y);
            }
            else
            {
                brain.rb.velocity = new Vector2(-1 * brain.Speed, brain.rb.velocity.y);
            }




        }
        else
        {
            Flip();
        }

        //brain.transform.position = Vector3.Lerp(brain.transform.position, brain.enemyToFollow.position, Time.deltaTime * 2f);
    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }

    public override void DeinitState(CommanderBrain controller)
    {
        //animacje
        base.DeinitState(controller);
    }

}
