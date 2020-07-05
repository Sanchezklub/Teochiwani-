using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kasacz : BaseWeapon
{
    public float PoisonDamage;
    public int PoisonCount;
    public float PoisonTimeBetween;



    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("kasacz :: Attack() - Player attacked with kasacz");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+GameController.instance.DataStorage.PlayerInfo.damage);
            enemy.GetComponent<Health>()?.PoisonEffect(PoisonDamage,PoisonCount,PoisonTimeBetween);

        }
    }

    
    
    
}