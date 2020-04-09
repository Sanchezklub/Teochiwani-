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
        brain.SpiderRigidbody.velocity = new Vector2(0, 0);
        brain.SpiderRigidbody.gravityScale = 0;
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
            GameObject projectile = GameObject.Instantiate(brain.SpiderProjectile, brain.FirePoint.position, Quaternion.identity) as GameObject;
            ///Instantiate(SpiderProjectile, brain.transform.position, Quaternion.identity);
            brain.nextFire = Time.time + brain.fireRate;
        }
    }
    public override void DeinitState(SpiderBrain controller)
    {
        base.DeinitState(controller);
        brain.SpiderRigidbody.gravityScale = 1;
    }
    public void GetStuned()
    {
        brain.StartStun();
    }
}