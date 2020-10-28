using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolotlRestState : BaseState<XolotlBrain>
{
    private GameObject Player;
    private XolotlBrain brain;
    public float currentRestTime;
    public override void InitState(XolotlBrain controller)
    {

        base.InitState(controller);
        this.brain = controller;
        brain.sr.color = new Color (0,1,0,1 );
        currentRestTime=0;
        brain.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player = GameObject.Find("Player");
        Debug.Log("Xolotl rest");
        // 6 animacja 
    }
    
    public override void UpdateState()
    {
        TimeCheck();
    }

    private void TimeCheck()
    {
        currentRestTime += Time.deltaTime;
        if (currentRestTime > brain.RestTime + Time.deltaTime)
        {
            if(  Mathf.Abs(brain.transform.position.x - Player.transform.position.x) > 300 )
            {
            brain.StartRest();   

            }
            else
            {
            brain.StartAttackBlood();
            brain.animator.SetBool("Vomit",true);
            brain.animator.SetBool("Rest",false);
            }
        }
    }
    public override void DeinitState(XolotlBrain controller)
    {
        
        base.DeinitState(controller);
    }
}
