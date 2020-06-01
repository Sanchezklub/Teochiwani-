﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{    

    public float attackrate = 2f;
    float nextAttackTime = 0f;
    public string AnimType;
    public float MaxComboDelay=2;
    public int noOfClicks = 0;
    float lastClickedTime=0;
  
    public BaseItem item;
    private BaseWeapon collidedWeapon;
    public BaseWeapon currentWeapon;
  
    public Transform holdPosition;
    public Animator animator;
    
    void Update()
    {
        if (Time.time - lastClickedTime > MaxComboDelay)
        {
            noOfClicks = 0;
        }
      
        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            lastClickedTime = Time.time;
            noOfClicks++;
            if(noOfClicks == 1)
            {
                 if (currentWeapon != null)
                 {
                    animator.SetBool("IsAttacking", true);
                    animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), true);
                 }
            }                
            nextAttackTime = Time.time +1f / attackrate;
            noOfClicks = Mathf.Clamp(noOfClicks,0,3);
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
    
   /* void StartAttack()
    {
        if (currentWeapon != null)
        {
            animator.SetBool("IsAttacking", true);
            animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), true);
        }
    }
    */
    public void DoAttack()
    {
        currentWeapon?.Attack(this);
       // animator.SetBool("IsAttacking", false);
      //  animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), false);
    }

    public void ChangeWeapon(BaseWeapon newWeapon)
    {
       
            EventController.instance.weaponEvents.CallOnWeaponPickup(currentWeapon, newWeapon);
            FindObjectOfType<AudioManager>().Play("PickUpWeapon");
            //Do something about wpn;
            Debug.Log(newWeapon.name);
            currentWeapon?.DropWeapon();
            GameController.instance.DataStorage.PlayerInfo.currentweaponID = newWeapon.id;
            currentWeapon = newWeapon;
            currentWeapon?.PickupWepaon();
            currentWeapon.Handle.transform.parent = holdPosition;
            currentWeapon.Handle.transform.localPosition = Vector3.zero;
            currentWeapon.Handle.transform.localEulerAngles = new Vector3(0, 0, 0);
     
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
    public void return1()
    {
        if (noOfClicks >= 2)
        {
            animator.SetBool("AttackCombo",true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), false);
            noOfClicks=0;
        }
    }
    public void return2()
    {
        if (noOfClicks >= 3)
        {
            animator.SetBool("AttackCombo2",true);
        }
        else
        {
            animator.SetBool("AttackCombo",false);
            animator.SetBool("IsAttacking", false);
            animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), false);
            noOfClicks=0;
        }
    }
    public void return3()
    {
        animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), false);
        animator.SetBool("IsAttacking",false);
        animator.SetBool("AttackCombo",false);
        animator.SetBool("AttackCombo2",false); // Combo zrobiłem z tego poradnika https://www.youtube.com/watch?v=53Z7N-x09_k
        noOfClicks=0;
        
    }

    
}
