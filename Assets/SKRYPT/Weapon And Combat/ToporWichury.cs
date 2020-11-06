using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToporWichury : BaseWeaponCloseCombat
 {
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float LaunchForce;
    public override void Attack(PlayerCombat controller)
    {
        /*
        Debug.Log("Topor Wichury :: Attack() - Player attacked with Topor Wichury");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage+info.damage);
            Effects(enemy);

        }
        */
        GameObject newArrow = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)&& PickUped)
        {
        GameObject newArrow = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        }
    }
    
}