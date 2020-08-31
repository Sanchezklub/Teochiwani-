using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGun : BaseWeapon
{
    public GameObject bulletPrefab;
    public float LaunchForce;
    public override void Attack(PlayerCombat controller)
    {
        controller.animator.SetBool("Reloaded", false);
        controller.animator.SetBool("IsAttacking", false);
        controller.animator.SetBool("IsAttackingShoot", false);
        Debug.Log("RockGun :: Attack() - Player attacked with RockGun");
        AudioManager.instance.Play("Rock Gun");
        GameObject newArrow =Instantiate(bulletPrefab, AttackPoint.position, AttackPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
    }
    public  void AdditonalVoid(PlayerCombat controller)
    {
        controller.animator.SetBool("Reloaded", true);
    }
}
