using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerFollowState : BaseState<EvilPlayerBrain>
{

    EvilPlayerBrain brain;
    float PositionDifference;
    bool LastMovedRight;
    public override void InitState(EvilPlayerBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;

        //brain.animator.SetBool("iswalking", true);
        //controller.Attacking += DamageTaken;
        PositionDifference = brain.transform.position.x - GameController.instance.DataStorage.PlayerInfo.playerPosition.x;
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
        //brain.sr.color = new Color(0, 0, 0 ,1);
    }

    // public void DamageTaken()
    // {

    //brain.Attacking -= DamageTaken;
    //brain.StartAttack();
    //  }

    public override void UpdateState()
    {
        base.UpdateState();
        MoveTowardsPlayer();
        float distance = Mathf.Abs(Vector3.Distance(brain.transform.position, GameController.instance.DataStorage.PlayerInfo.playerPosition));
        if (brain.combat.currentWeapon != null)
        {
            if (distance < brain.AttackDist || (distance < brain.RangedAttackDist && (brain.combat.currentWeapon.AttackAnimationType == BaseWeapon.AnimationType.IsAttackingRanged || brain.combat.currentWeapon.AttackAnimationType == BaseWeapon.AnimationType.IsAttackingShoot || brain.combat.currentWeapon.AttackAnimationType == BaseWeapon.AnimationType.IsAttackingThrow)))
            {
                brain.StartAttack();
            }
        }

        /*
        if(Physics2D.Raycast(brain.RaycastTransform.position, Vector2.right, 7f, brain.WhatIsGround))
        {
            Flip();
        }
        
        /*if (Physics2D.Raycast(brain.RaycastTransform.position, Vector2.down, 2f, brain.WhatIsGround))
        {
            Debug.Log("Did hit");
            */
        /*

        }

        else
        {
            brain.rb.velocity = new Vector2(0, 0);
            //Debug.Log("Did not");
            //enemyAnimator.SetBool(Keys.IDLE_ANIM_KEY, true);
            //enemyAnimator.SetBool(Keys.WALK_ANIM_KEY, false);
            //enemyAnimator.SetBool(Keys.ATTACK_ANIM_KEY, false);



        }*/
    }

    public override void DeinitState(EvilPlayerBrain controller)
    {
        controller.animator.SetFloat("Speed", 0);
        base.DeinitState(controller);
        //brain.animator.SetBool("iswalking", false);
    }
    void MoveTowardsPlayer()
    {
        Debug.Log("Moved towards player");
        PositionDifference = brain.transform.position.x - GameController.instance.DataStorage.PlayerInfo.playerPosition.x;
        if (PositionDifference >= .5f)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
            brain.rb.velocity = new Vector2(-1 * GameController.instance.DataStorage.EvilPlayerInfo.speed, brain.rb.velocity.y);
            brain.animator.SetFloat("Speed", Mathf.Abs(brain.rb.velocity.x));
        }
        else if (PositionDifference < -.5f)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            brain.rb.velocity = new Vector2(1 * GameController.instance.DataStorage.EvilPlayerInfo.speed, brain.rb.velocity.y);
            brain.animator.SetFloat("Speed", brain.rb.velocity.x);
        }
        else if (LastMovedRight)
        {
            brain.rb.velocity = new Vector2(1 * GameController.instance.DataStorage.EvilPlayerInfo.speed, brain.rb.velocity.y);
            brain.animator.SetFloat("Speed", brain.rb.velocity.x);
        }
        else
        {
            brain.rb.velocity = new Vector2(-1 * GameController.instance.DataStorage.EvilPlayerInfo.speed, brain.rb.velocity.y);
            brain.animator.SetFloat("Speed", Mathf.Abs(brain.rb.velocity.x));
        }

    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }
}
