using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kasacz : BaseWeapon
{
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("kasacz :: Attack() - Player attacked with kasacz");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+GameController.instance.DataStorage.PlayerInfo.damage);
            
            enemy.GetComponent<Health>()?.Effect(PoisonDamage,PoisonCount,PoisonTimeBetween,0);

            if ( EffectBleed == true)
            {
                enemy.GetComponent<Health>()?.Effect(BleedDamage,BleedCount,BleedTimeBetween,0);
            }
            if ( EffectFire == true)
            {
                enemy.GetComponent<Health>()?.Effect(FireDamage,FireCount,FireTimeBetween,1);
            }
            if ( EffectPoison == true)
            {
                enemy.GetComponent<Health>()?.Effect(PoisonDamage,PoisonCount,PoisonTimeBetween,2);
            }
        }
    }

    
    
    
}