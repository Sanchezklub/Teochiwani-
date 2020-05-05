using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KhnurAtak2 : BaseState<KhnurBrain>
{
    [SerializeField]
    private KhnurBrain brain;

    public override void InitState(KhnurBrain controller)
    {
        this.brain = controller;
        brain.Boar += CreateBoar;
        brain.enemyAnimator.SetBool("Atak2", true);
        brain.LeaveFightState += AttemptLeavingFightState;
    }
    public override void UpdateState()
    {
        base.UpdateState();
    }

    void CreateBoar()
    {
        // while (i < rand) 
        GameObject Dzik = GameObject.Instantiate(brain.Dzik, brain.FirePoint.position, Quaternion.identity) as GameObject;
        //if (Time.time > brain.nextFire)
        //{
        //Instantiate(Dzik, brain.transform.position, Quaternion.identity);
        //brain.nextFire = Time.time + brain.fireRate;
        // }
    }
    public void AttemptLeavingFightState()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1 || brain.SummonCount >= 3)
        {
            brain.SummonCount = 0;
            Debug.Log("left fightstate");
            brain.StartAtak1();
        }
        else
        {
            brain.SummonCount++;
            Debug.Log("left fightstate");
            brain.StartAtak2();
        }
    }
    public override void DeinitState(KhnurBrain controller)
    {
        base.DeinitState(controller);
        brain.Boar -= CreateBoar;
        brain.enemyAnimator.SetBool("Atak2", false);
        brain.LeaveFightState -= AttemptLeavingFightState;
    }
}
