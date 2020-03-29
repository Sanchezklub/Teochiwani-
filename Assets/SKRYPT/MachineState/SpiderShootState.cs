using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShootState : BaseState<SpiderBrain>
{
    [SerializeField]
    private SpiderBrain brain;

    public override void InitState(SpiderBrain controller)
    {
        this.brain = controller;
        brain.fireRate = 1f;
        brain.nextFire = Time.time;
    }
    public override void UpdateState()
    {
        base.UpdateState();
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if (Time.time > brain.nextFire)
        {
            GameObject xyzadjasd = GameObject.Instantiate(brain.SpiderProjectile, brain.FirePoint.position, Quaternion.identity) as GameObject;
            ///Instantiate(SpiderProjectile, brain.transform.position, Quaternion.identity);
            brain.nextFire = Time.time + brain.fireRate;
        }
    }
}