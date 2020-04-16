using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KapiChannellingState : BaseState<KapiBrain>
{
    private KapiBrain brain;
    private Animator enemyAnimator;
    Rigidbody2D enemyRigidBody2D;
    private GameObject player;
    private float CurrentTime;
    private float ChannellingTime;
    public override void InitState(KapiBrain controller)
    {
        base.InitState(controller);
       // var renderer = controller.gameObject.GetComponent<MeshRenderer>();
      //  renderer.material.color = Color.green;
        this.brain = controller;

        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        //Rigidbody2D.constraints = Rigidbody2DConstraints.FreezeRotationX;


        if (brain.FacingRight == false)
        {
            brain.transform.Rotate(new Vector2(0f, 180f));
        }
    }
    public override void UpdateState()
    {
           
    }
    private void TimeCheck()
    {
        //if CurrentTime >= ChannellingTime
        //zrob fikola
    }


    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
    }
    public override void DeinitState(KapiBrain controller)
    {
        base.DeinitState(controller);
        //Rigidbody2D.constraints = Rigidbody2DConstraints.None; hwdp
    }
}

