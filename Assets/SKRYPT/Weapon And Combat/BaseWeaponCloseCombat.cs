using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeaponCloseCombat : BaseWeapon
{
    public override void Attack(PlayerCombat controller)
    {}
    /*{
        Debug.Log("WoodenSword :: Attack() - Player attacked with WoodenSword");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+info.damage);
            Effects(enemy);

        }
        //AudioManager.instance.Play("Sword");
    }*/
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Attacking)
        {
            EnemyWas=false;
            for (int i = 0; i < EnemyId.Length; i++)
            {
                if ( EnemyId[i]==collision.gameObject.GetInstanceID() )
                {
                    EnemyWas=true;
                }
            }
            if ( EnemyWas==false)
            {
                collision.gameObject.GetComponent<Health>()?.TakeDamage(attackdamage+info.damage);
                EnemyId[EnemyCounter]=collision.gameObject.GetInstanceID();
                Effects(collision);
            }
        }
    }
}
