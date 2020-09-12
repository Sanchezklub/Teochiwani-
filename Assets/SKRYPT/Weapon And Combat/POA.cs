using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POA : BaseWeapon
{

    public float Playercurrenthealth;   
    
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("POA :: Attack() - Player attacked with POA");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+info.damage);
            Effects(enemy);

        }
    }
    public override void DropWeapon()
    {
        base.DropWeapon();
        GameController.instance.DataStorage.PlayerInfo.currenthealth+=Playercurrenthealth-1; 
    }
    public override void PickupWepaon()
    {
        base.PickupWepaon();
        Playercurrenthealth=GameController.instance.DataStorage.PlayerInfo.currenthealth;
        GameController.instance.DataStorage.PlayerInfo.currenthealth=1;
    }
     
}