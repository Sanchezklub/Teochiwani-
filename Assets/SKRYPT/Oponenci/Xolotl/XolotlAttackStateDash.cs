using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class XolotlAttackStateDash : BaseState<XolotlBrain>
{

    private GameObject Player;
    private XolotlBrain brain;
    private float x;
    public override void InitState(XolotlBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;

        Player = GameObject.Find("Player");
        Debug.Log("Xolotl dashInit");
        DashY();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(brain.transform.position.y < 0 )
        {
            brain.StartRest();
        }
    }

    public void DashY()
    {
        x=Player.transform.position.x;
        brain.transform.position=new Vector3(x, 100, brain.transform.position.z);
        brain.rb2d.velocity = new Vector2(0,-brain.DashSpeed);
        brain.boxCollider2D.isTrigger=true;
        //Debug.Log("Xolotl dashes");
        
        
    }

    

   
    public override void DeinitState(XolotlBrain controller)
    {
        brain.transform.position=new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
        brain.boxCollider2D.isTrigger=false;
        base.DeinitState(controller);
    }
}
