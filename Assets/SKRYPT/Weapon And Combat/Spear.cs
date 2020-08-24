using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : BaseWeapon
{
    bool hasHit;
    Vector2 direction; 
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float LaunchForce;
    bool flying = false;

    public Rigidbody2D rb;
    public PolygonCollider2D pc;

public Collider2D[] hitEnemies;
    public void Update()
    {
        if ( PickUped )
        {
        Vector2 bowPosition = Handle.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        Handle.transform.right=direction;
        }  
        if (flying)
        {
            if(hasHit==false)
            {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x)* Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward );
            }
        }
        
    }
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Spear :: Attack() - Player attacked with Spear");
        //GameObject newArrow = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        flying=true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(flying)
        {
            hasHit=true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        pc.isTrigger=true;
        hitEnemies = Physics2D.OverlapCircleAll(Handle.transform.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)         
        {
        enemy.GetComponent<Health>()?.TakeDamage(attackdamage);
        if ( EffectBleed)
        {
            enemy.GetComponent<Health>()?.Effect(BleedDamage,BleedCount,BleedTimeBetween,0);
        }
        
        if ( EffectFire)
        {
            enemy.GetComponent<Health>()?.Effect(FireDamage,FireCount,FireTimeBetween,1);
        }
        if ( EffectPoison)
        {
            enemy.GetComponent<Health>()?.Effect(PoisonDamage,PoisonCount,PoisonTimeBetween,2);
        }
        }
        }

        
        
    }
}
