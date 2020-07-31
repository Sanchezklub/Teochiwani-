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
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+GameController.instance.DataStorage.PlayerInfo.damage);

        }
    }
    public override void DropWeapon()
    {
        GameController.instance.DataStorage.PlayerInfo.speed=Playercurrentspeed; 
        Handle.transform.parent = null;
        coll.enabled = true;
        Handle.transform.localEulerAngles = new Vector3(0,0,0); 
    }
    public override void PickupWepaon()
    {
        coll.enabled = false;
        ShowFloatingText();
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
        Playercurrentspeed=GameController.instance.DataStorage.PlayerInfo.speed;
        GameController.instance.DataStorage.PlayerInfo.speed+=20;
    }
      
}