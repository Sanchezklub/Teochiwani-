using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerCombat : PlayerCombat
{
    public LayerMask OponentLayers;
    [SerializeField] private EvilPlayerBrain brain;
    public bool isAttacking;
    public override void ChangeWeapon(BaseWeapon newWeapon)
    {

        //EventController.instance.weaponEvents.CallOnWeaponPickup(currentWeapon, newWeapon);
        FindObjectOfType<AudioManager>().Play("PickUpWeapon");
        //Do something about wpn;
        Debug.Log(newWeapon.name);
        currentWeapon?.DropWeapon();
        //GameController.instance.DataStorage.PlayerInfo.currentweaponID = newWeapon.id;
        //GameController.instance.DataStorage.PlayerInfo.currentweaponModID = newWeapon.ModId;
        currentWeapon = newWeapon;
        currentWeapon.gameObject.layer = 22;
        currentWeapon.info = GameController.instance.DataStorage.EvilPlayerInfo;
        currentWeapon?.PickupWepaon();
        currentWeapon.Handle.transform.parent = holdPosition;
        currentWeapon.enemyLayers = OponentLayers;
        currentWeapon.Handle.transform.localPosition = Vector3.zero;
        currentWeapon.Handle.transform.localEulerAngles = new Vector3(0, 0, 0);
        currentWeapon.StopEmitting();

    }

    protected override void Update()
    {
        animator.SetFloat("AttackSpeed", GameController.instance.DataStorage.EvilPlayerInfo.attackspeed);
        animator.SetFloat("Speed1", GameController.instance.DataStorage.EvilPlayerInfo.speed / startingspeed);
    }
    public override void CancelAllAttacks()
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
        isAttacking = false;
    }
    /*
    public void WeaponStartEmitting()
    {
        currentWeapon?.StartEmitting();
    }

    public void WeaponStopEmitting()
    {
        currentWeapon?.StopEmitting();
    }
    */

    public void Attack()
    {

        //lastClickedTime = Time.time;
        //noOfClicks++;
        Debug.Log("Evil player attack called");
            if (currentWeapon != null)
            {
                animator.SetBool("IsAttacking", true);
                animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), true);
                isAttacking = true;
            }


            //noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
    }
    public void EvilDoAttack()
    {
        currentWeapon?.Attack(this);
    }

    public void EvilEndAttack()
    {
        Debug.Log("EvilEndAttack :: EvilPlayerCombat");
        CancelAllAttacks();
        brain.StartFollow();
    }
    public override void return1()
    {
    }
    public override void return2()
    {
    }
    public override void return3()
    {
    }
}
