using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodensword : BaseWeapon
{
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("WoodenSword :: Attack() - Player attacked with WoodenSword");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+info.damage);
            Effects(enemy);

        }
        AudioManager.instance.Play("Sword");
    }

     
}