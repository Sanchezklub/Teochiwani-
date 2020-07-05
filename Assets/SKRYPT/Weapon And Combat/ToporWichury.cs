using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToporWichury : BaseWeapon
 {
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Topor Wichury :: Attack() - Player attacked with Topor Wichury");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+GameController.instance.DataStorage.PlayerInfo.damage);

        }
    }

      
    
}