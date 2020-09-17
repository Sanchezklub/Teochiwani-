using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerCombat : MonoBehaviour
{
    public BaseWeapon currentWeapon;
    public Transform holdPosition;
    public Animator animator;
    public LayerMask OponentLayers;
    public float nextAttackTime;
    public void ChangeWeapon(BaseWeapon newWeapon)
    {

        //EventController.instance.weaponEvents.CallOnWeaponPickup(currentWeapon, newWeapon);
        FindObjectOfType<AudioManager>().Play("PickUpWeapon");
        //Do something about wpn;
        Debug.Log(newWeapon.name);
        currentWeapon?.DropWeapon();
        //GameController.instance.DataStorage.PlayerInfo.currentweaponID = newWeapon.id;
        //GameController.instance.DataStorage.PlayerInfo.currentweaponModID = newWeapon.ModId;
        currentWeapon = newWeapon;
        currentWeapon?.PickupWepaon();
        currentWeapon.Handle.transform.parent = holdPosition;
        currentWeapon.info = GameController.instance.DataStorage.EvilPlayerInfo;
        currentWeapon.enemyLayers = OponentLayers;
        currentWeapon.Handle.transform.localPosition = Vector3.zero;
        currentWeapon.Handle.transform.localEulerAngles = new Vector3(0, 0, 0);
        currentWeapon.StopEmitting();

    }

    public void CancelAllAttacks()
    {
        animator.SetBool("IsAttacking", false);
        animator.SetBool("IsAttackingVLight", false);
        animator.SetBool("IsAttackingSword", false);
        animator.SetBool("IsAttackingLight", false);
        animator.SetBool("IsAttackingVHeavy", false);
        animator.SetBool("IsAttackingRanged", false);
        animator.SetBool("IsAttackingShoot", false);
        animator.SetBool("IsAttackingThrow", false);
        animator.SetBool("AttackCombo", false);
        animator.SetBool("AttackCombo2", false);
        //noOfClicks = 0;
        WeaponStopEmitting();
    }
    public void WeaponStartEmitting()
    {
        currentWeapon?.StartEmitting();
    }

    public void WeaponStopEmitting()
    {
        currentWeapon?.StopEmitting();
    }

    public void Attack()
    {
        if (Time.time > nextAttackTime)
        {
            //lastClickedTime = Time.time;
            //noOfClicks++;
            if (currentWeapon != null)
            {
                animator.SetBool("IsAttacking", true);
                animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), true);
            }

            nextAttackTime = Time.time + 0.5f;

            //noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        }
    }
}
