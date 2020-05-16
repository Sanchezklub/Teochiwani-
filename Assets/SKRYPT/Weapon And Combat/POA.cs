using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POA : BaseWeapon
{
    public bool FacingRight = true;
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    public Collider2D coll;
    public float attackRange;
    public float attackdamage;

    
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
               
     
        Handle.transform.parent = null;
        
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
        coll.enabled = true;
    }

    public override void PickupWepaon()
    {
        coll.enabled = false;
        ShowFloatingText(FlavourText);
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
    }
}