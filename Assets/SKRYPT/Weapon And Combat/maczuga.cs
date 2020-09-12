using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maczuga : BaseWeapon
{
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("maczuga :: Attack() - Player attacked with maczuga");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+info.damage);
            Effects(enemy);
        }
    }

     
}