using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public int attackdamage = 40;
  public float attackrate = 2f;
  float nextAttackTime=0f;

    void Update()
    {
        if(Time.time>=nextAttackTime)
        {

       if(Input.GetKeyDown(KeyCode.Mouse0)) 
       {
           Atak();
           nextAttackTime = Time.time +1f / attackrate;
       }
       
       }
    }
    
    void Atak()
    {
        
        Collider2D[] hitEnemies= Physics2D.OverlapCircleAll(AttackPoint.position,attackRange,enemyLayers); 
        foreach(Collider2D enemy in hitEnemies)
         {
            enemy.GetComponent<Enemy>().TakeDamage(attackdamage);
            
        }
    }

    void OnDrawGizmosSelected()
    {
        if(AttackPoint==null)
        return;
        Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }
}
