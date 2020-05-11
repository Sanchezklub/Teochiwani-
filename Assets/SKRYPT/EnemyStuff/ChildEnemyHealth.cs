using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEnemyHealth : Health
{
    private GameObject Hitbox;
    private GameObject parent;
    protected override void Start()
    {
        base.Start();
        parent = this.transform.parent.gameObject;
    }

    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        base.TakeDamage(damage);

    }

    protected override void Die()
    {
        Destroy(parent);
    }

}
