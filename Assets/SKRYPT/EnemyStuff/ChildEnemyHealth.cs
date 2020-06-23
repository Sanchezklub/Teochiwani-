using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEnemyHealth : Health
{
    private GameObject Hitbox;
    private EnemyHealth parentHealth;
    protected override void Start()
    {
        base.Start();
        parentHealth = this.transform.parent.GetComponent<EnemyHealth>();
    }

    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        parentHealth.TakeDamage(damage);

    }
}
