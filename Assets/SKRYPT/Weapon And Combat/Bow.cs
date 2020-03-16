using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
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
        transform.parent = null;
        coll.enabled = true;
    }

    public override void PickupWepaon()
    {
        coll.enabled = false;
    }
}
