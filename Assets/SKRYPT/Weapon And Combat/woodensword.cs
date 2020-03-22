using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodensword : BaseWeapon
{
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    public Collider2D coll;

    public float attackRange;
    public float attackdamage;

    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("WoodenSword :: Attack() - Player attacked with WoodenSword");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage);

        }
    }

    public override void DropWeapon()
    {
        transform.parent = null;
        coll.enabled = true;
    }

    public override void PickupWepaon()
    {
        coll.enabled = false;
    }
}
