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
    public BaseItem item;
    public Transform holdPosition;
    private BaseWeapon collidedWeapon;
    public BaseWeapon currentWeapon;
    public Animator animator;
    public string AnimType;
    
    void Update()
    {
        if(Time.time>=nextAttackTime)
        {
           if(Input.GetKeyDown(KeyCode.Mouse0)) 
           {
               StartAttack();
               nextAttackTime = Time.time +1f / attackrate;
           }
        }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (collidedWeapon!= null)
                {
                    ChangeWeapon(collidedWeapon);
                }
                if(item != null)
                {
                item?.PickupItem();
                }
            }
        
    }
    
    void StartAttack()
    {
        if (currentWeapon != null)
        {
            animator.SetBool("IsAttacking", true);
            animator.SetBool(currentWeapon?.AnimationType, true);
        }
    }

    public void DoAttack()
    {
        currentWeapon?.Attack(this);
        animator.SetBool("IsAttacking", false);
        animator.SetBool(currentWeapon?.AnimationType, false);
    }

    public void ChangeWeapon(BaseWeapon newWeapon)
    {
        //Do something about wpn;
        Debug.Log(newWeapon.name);
        currentWeapon?.DropWeapon();
        GameController.instance.DataStorage.PlayerInfo.currentWeapon = newWeapon.name;
        currentWeapon = newWeapon;
        currentWeapon?.PickupWepaon();
        currentWeapon.Handle.transform.parent = holdPosition;
        currentWeapon.Handle.transform.localPosition = Vector3.zero;
        currentWeapon.Handle.transform.localEulerAngles = new Vector3(0,0,0);

    }

    void OnDrawGizmosSelected()
    {
        //if(AttackPoint==null)
        //return;
        //Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        item = collision.GetComponent<BaseItem>();
        collidedWeapon = collision.GetComponent<BaseWeapon>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        item = null;
        collidedWeapon = null;
    }
    
}
