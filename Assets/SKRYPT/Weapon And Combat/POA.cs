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
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+GameController.instance.DataStorage.PlayerInfo.damage);

        }
    }
    public override void DropWeapon()
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth+=Playercurrenthealth-1;  
    }
    public override void PickupWepaon()
    {
        Playercurrenthealth=GameController.instance.DataStorage.PlayerInfo.currenthealth;
        GameController.instance.DataStorage.PlayerInfo.currenthealth=1;
    }
     
}