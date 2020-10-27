using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XolotlAttackStateBlood : BaseState<XolotlBrain>
{
    private XolotlBrain brain;
    public float currentBloodTime;
    public override void InitState(XolotlBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        Debug.Log("Xolotl Blood");
        brain.sr.color = new Color (0,1,1,1 );
        currentBloodTime=0;
        //brain.StartAttackDash();
        brain.transform.position=new Vector3(brain.Podest[0].transform.position.x, brain.Podest[0].transform.position.y+5, brain.Podest[0].transform.position.z);
        brain.rb2d.bodyType = RigidbodyType2D.Static;
        
    }
    public override void UpdateState()
    {
        //base.UpdateState();
        TimeCheck();
    }
    private void TimeCheck()
    {
        currentBloodTime += Time.deltaTime;
        if (currentBloodTime > brain.TimeAfterBloodRise&& currentBloodTime < brain.TimeAfterBloodLowers )
        {
            brain.Blood.SetActive(true);
            brain.Blood.transform.Translate(Vector3.up * brain.RisingVelocity * Time.deltaTime);
        }

        if (currentBloodTime > brain.TimeAfterBloodLowers && currentBloodTime < brain.TimeAfterBloodEnds )
        {
            brain.Blood.transform.Translate(Vector3.down * brain.RisingVelocity * Time.deltaTime);
        }
        if (currentBloodTime > brain.TimeAfterBloodEnds )
        {
            brain.Blood.SetActive(false);
            brain.StartAttackDash();
            brain.rb2d.bodyType = RigidbodyType2D.Dynamic;
            
        }
    }
    
    public override void DeinitState(XolotlBrain controller)
    {
        brain.Blood.SetActive(false);
        base.DeinitState(controller);
    }
}
