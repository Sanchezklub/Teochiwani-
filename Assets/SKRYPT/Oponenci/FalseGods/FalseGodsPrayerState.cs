using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGodsPrayerState : BaseState<FalseGodsBrain>
{
    private FalseGodsBrain brain;

    private float ProjectileX;
    public override void InitState(FalseGodsBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        Projectile();
    }

    void Projectile()
    {
        for (int i = 0; i < brain.ProjectileAmount; i++)
        {
            ProjectileX = Random.Range(brain.ProjectileMinX, brain.ProjectileMaxX);
            Object.Instantiate(brain.Projectile, new Vector2(brain.transform.position.x + ProjectileX, brain.transform.position.y + brain.ProjectileY), Quaternion.identity);
        }
        brain.StartRun();
    }

    public override void DeinitState(FalseGodsBrain controller)
    {
        base.DeinitState(controller);
    }
}
