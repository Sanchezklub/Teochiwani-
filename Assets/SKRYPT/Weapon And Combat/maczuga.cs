﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maczuga : BaseWeapon
{
    public bool FacingRight = true;
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    public Collider2D coll;
    public float attackRange;
    public float attackdamage;

   
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("maczuga :: Attack() - Player attacked with maczuga");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+GameController.instance.DataStorage.PlayerInfo.damage);

        }
    }

      public override void DropWeapon()
    {
                
       if (this != null)
        {
            Handle.transform.parent = null;

            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            coll.enabled = true;
        }

    }

    public override void PickupWepaon()
    {
        coll.enabled = false;
        ShowFloatingText(FlavorText);
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
    }
}