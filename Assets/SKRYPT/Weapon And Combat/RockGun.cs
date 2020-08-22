using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGun : BaseWeapon
{
    public GameObject bulletPrefab;
    public float LaunchForce;
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("RockGun :: Attack() - Player attacked with RockGun");
        GameObject newArrow =Instantiate(bulletPrefab, AttackPoint.position, AttackPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        controller.animator.SetBool("Reloaded", false);
    }
    public  void AdditonalVoid(PlayerCombat controller)
    {
        controller.animator.SetBool("Reloaded", true);
    }
}
