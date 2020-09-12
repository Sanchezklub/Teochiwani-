using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MieczTysiacaKrokow : BaseWeapon
{
    public float Playercurrentspeed;
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("MieczTysiącaKrokow :: Attack() - Player attacked with MieczTysiącaKrokow");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+info.damage);
            Effects(enemy);

        }
        AudioManager.instance.Play("Sword");
    }
    public override void DropWeapon()
    {
        GameController.instance.DataStorage.PlayerInfo.speed=Playercurrentspeed;
        base.DropWeapon();
    }
    public override void PickupWepaon()
    {
        base.PickupWepaon();
        Playercurrentspeed=GameController.instance.DataStorage.PlayerInfo.speed;
        GameController.instance.DataStorage.PlayerInfo.speed+=20;
    }
      
}