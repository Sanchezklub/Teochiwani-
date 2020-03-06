using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : BaseState<BaseEnemy>
{
    private BaseEnemy brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;

    public override void InitState(BaseEnemy controller)
    {
        base.InitState(controller);
       // var renderer = controller.gameObject.GetComponent<MeshRenderer>();
      //  renderer.material.color = Color.green;
        this.brain = controller;

        this.enemyAnimator = controller.enemyAnimator;
        enemyAnimator.SetBool(Keys.PATROL_ANIM_KEY, true);
        player = GameObject.Find("Player");
        controller.OnDamageTaken += DamageTaken;
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
    }

    public void DamageTaken()
    {
        brain.OnDamageTaken -= DamageTaken;
        brain.StartFight();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        float distance = Vector3.Distance(brain.transform.position, player.transform.position);
        
        if(distance < 5f)
        {
            brain.StartFight();
        }


        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(brain.raycastTransform.position, Vector2.down, out hit, 10f))
        {
            
            Debug.DrawRay(brain.raycastTransform.position, Vector2.down * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            enemyRigidBody2D.velocity = new Vector2(brain.speed, 0);
            
        } else
        {
            brain.transform.Rotate(new Vector2(0f, 180f));
            Debug.Log("Did not");
        }

        //brain.transform.position = Vector3.Lerp(brain.transform.position, brain.enemyToFollow.position, Time.deltaTime * 2f);
    }

    public override void DeinitState(BaseEnemy controller)
    {
        base. DeinitState(controller);
    }
}
