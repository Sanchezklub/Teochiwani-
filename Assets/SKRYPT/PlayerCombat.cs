using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{    
   // public Transform AttackPoint;
   // public LayerMask enemyLayers;
    //public float attackRange = 0.5f;
    //public int attackdamage = 40;
    public float attackrate = 2f;
    float nextAttackTime = 0f;

    public Transform holdPosition;
    private BaseWeapon collidedWeapon;
    public BaseWeapon currentWeapon;

    void Update()
    {
        if(Time.time>=nextAttackTime)
        {
           if(Input.GetKeyDown(KeyCode.Mouse0)) 
           {
               Atak();
               nextAttackTime = Time.time +1f / attackrate;
           }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (collidedWeapon!= null)
                {
                    ChangeWeapon(collidedWeapon);
                }
            }
        }
    }
    
    void Atak()
    {
        currentWeapon.Attack(this);
    }

    public void ChangeWeapon(BaseWeapon newWeapon)
    {
        //Do something about wpn;
        Debug.Log(newWeapon.name);
        currentWeapon?.DropWeapon();
        currentWeapon = newWeapon;
        currentWeapon?.PickupWepaon();
        currentWeapon.transform.parent = holdPosition;

    }

    void OnDrawGizmosSelected()
    {
        //if(AttackPoint==null)
        //return;
        ///Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedWeapon = collision.GetComponent<BaseWeapon>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidedWeapon = null;
    }
}
