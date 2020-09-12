using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{

    public GameObject bulletPrefab;
    public float LaunchForce;
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Bow :: Attack() - Player attacked with bow");
        GameObject newArrow =Instantiate(bulletPrefab, AttackPoint.position, AttackPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        newArrow.GetComponent<Strzala>().weapon = this;
        AudioManager.instance.Play("Bow");
    }
  
    
}
