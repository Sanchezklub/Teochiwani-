using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class XolotlAttackStateDash : BaseState<XolotlBrain>
{

    private GameObject Player;
    private XolotlBrain brain;
    bool dashX,dashY,dashXY;
    public override void InitState(XolotlBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        brain.sr.color = new Color (1,1,0,1 );
        dashX=false;
        dashY=false;
        dashXY=false;
        Player = GameObject.Find("Player");
        Debug.Log("Xolotl dashInit");
        DashY(); // 3 razy animacja 
    }

    public override void UpdateState()
    {
        //base.UpdateState();

        if(brain.transform.position.y < Player.transform.position.y-20 && dashY )
        {
            //brain.transform.position=new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
            dashY=false;
            DashX();
            
        }
        if (brain.transform.position.x > Player.transform.position.x + 100 && dashX )
        {
            dashX=false;
            brain.rb2d.constraints = RigidbodyConstraints2D.None;
            brain.rb2d.constraints = RigidbodyConstraints2D.FreezeRotation; 
            DashXY();
        }
        if (brain.transform.position.y < Player.transform.position.y-20 && dashXY )
        {
            brain.boxCollider2D.isTrigger=false;
            dashXY=false;
            brain.StartRest();

        }
    }

    public void DashY()
    {
        brain.XolotlHitbox.SetActive(true);
        brain.transform.position=new Vector3(Player.transform.position.x, Player.transform.position.y+100, brain.transform.position.z);
        brain.rb2d.velocity = new Vector2(0,-brain.DashSpeed);
        brain.transform.localEulerAngles =new Vector3(0,0,-90);
        brain.boxCollider2D.isTrigger=true;
        dashY=true;
        //Debug.Log("Xolotl dashes");
    }
    public void DashX()
    {
        brain.XolotlHitbox.SetActive(true);
        brain.transform.localEulerAngles =new Vector3(0,0,0);
        brain.transform.position=new Vector3(Player.transform.position.x-100, Player.transform.position.y, brain.transform.position.z);
        brain.rb2d.velocity = new Vector2(brain.DashSpeed, 0);
        brain.boxCollider2D.isTrigger=true;
        brain.rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
        dashX=true;
        //Debug.Log("Xolotl dashes");
    }
    public void DashXY()
    {
        brain.XolotlHitbox.SetActive(true);
        brain.transform.localEulerAngles =new Vector3(0,0,-45);
        brain.transform.position=new Vector3(Player.transform.position.x-100, Player.transform.position.y+100, brain.transform.position.z);
        brain.rb2d.velocity = new Vector2(brain.DashSpeed,-brain.DashSpeed);
        brain.boxCollider2D.isTrigger=true;
        dashXY=true;
    }
   
    public override void DeinitState(XolotlBrain controller)
    {
        brain.XolotlHitbox.SetActive(false);
        brain.transform.localEulerAngles =new Vector3(0,0,0);
        brain.transform.position=new Vector3(UnityEngine.Random.Range( Player.transform.position.x-100 , Player.transform.position.x+100 ) , 0,0);
        brain.boxCollider2D.isTrigger=false;
        base.DeinitState(controller);
        brain.animator.SetBool("Dash",false);
        brain.animator.SetBool("Rest",true);
    }
}
