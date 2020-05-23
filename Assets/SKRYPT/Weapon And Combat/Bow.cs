﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
    public bool FacingRight = true;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Collider2D coll;
   

    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Bow :: Attack() - Player attacked with bow");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public override void DropWeapon()
    {
    
        Handle.transform.parent = null;
        
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
        coll.enabled = true;
    }

    public override void PickupWepaon()
    {
        ShowFloatingText(FlavorText);

        coll.enabled = false;

        GameObject Player = GameObject.Find("Player");
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
        
    }
    
}
