using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : BaseWeapon
{
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Axe :: Attack() - Player attacked with axe");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+GameController.instance.DataStorage.PlayerInfo.damage);
            Effects(enemy);
        }
    }

   
}