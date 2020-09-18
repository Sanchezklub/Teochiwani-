using System.Collections;
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
    public LayerMask ItemMask;
    public LayerMask ItemMasks;
    public LayerMask EnemyLayers;

    public Transform holdPosition;
    public Animator animator;
    public float startingspeed;
    // attack speed zmieniam wedlug https://stackoverflow.com/questions/39524914/change-the-speed-of-animation-at-runtime-in-unity-c-sharp
    void Start()
    {
        startingspeed = GameController.instance.DataStorage.PlayerInfo.speed;
    }
    void Update()
    {
        if (Time.time - lastClickedTime > MaxComboDelay)
        {
            noOfClicks = 0;
        }
      
        if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextAttackTime) 
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

            nextAttackTime = Time.time +0.5f;
            
            noOfClicks = Mathf.Clamp(noOfClicks,0,3);
        }
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(this.transform.position, 2 , ItemMask);
            foreach (Collider2D Item in hitColliders)
            {
                Item.GetComponent<BaseItem>()?.PickupItem();
            }
            Collider2D[] hitColliderss = Physics2D.OverlapCircleAll(this.transform.position, 2 , ItemMasks);
            foreach (Collider2D Weapon in hitColliderss)
            {
                 ChangeWeapon(Weapon.GetComponent<BaseWeapon>());
            } 

        //    if (collidedWeapon!= null)
         //   {
           //     ChangeWeapon(collidedWeapon);
          //  }
           
        } 
        animator.SetFloat("AttackSpeed", GameController.instance.DataStorage.PlayerInfo.attackspeed);
        animator.SetFloat("Speed1", GameController.instance.DataStorage.PlayerInfo.speed/startingspeed);
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
    public void DoAttackSound()
    {
        currentWeapon?.SoundAttack();
       // animator.SetBool("IsAttacking", false);
      //  animator.SetBool(currentWeapon?.AttackAnimationType.ToString(), false);
    }
    public virtual void ChangeWeapon(BaseWeapon newWeapon)
    {
       
            EventController.instance.weaponEvents.CallOnWeaponPickup(currentWeapon, newWeapon);
            FindObjectOfType<AudioManager>().Play("PickUpWeapon");
            //Do something about wpn;
            Debug.Log(newWeapon.name);
            currentWeapon?.DropWeapon();
            GameController.instance.DataStorage.PlayerInfo.currentweaponID = newWeapon.id;
            GameController.instance.DataStorage.PlayerInfo.currentweaponModID = newWeapon.ModId;
            currentWeapon = newWeapon;
            currentWeapon?.PickupWepaon();
            currentWeapon.Handle.transform.parent = holdPosition;
            currentWeapon.Handle.transform.localPosition = Vector3.zero;
            currentWeapon.Handle.transform.localEulerAngles = new Vector3(0, 0, 0);
            currentWeapon.info = GameController.instance.DataStorage.PlayerInfo;
            currentWeapon.enemyLayers = EnemyLayers;
            currentWeapon.ShowFloatingText();
            currentWeapon.StopEmitting();
     
    }

    void OnDrawGizmosSelected()
    {
        //if(AttackPoint==null)
        //return;
        //Gizmos.DrawWireSphere(AttackPoint.position,attackRange);
    }
/*
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
    void OnTriggerStay2D(Collider2D collision)
    {
        item = collision.GetComponent<BaseItem>();
        collidedWeapon = collision.GetComponent<BaseWeapon>();
        
    }
    */
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
    public void WeaponStartEmitting()
    {
        currentWeapon?.StartEmitting();
    }

    public void WeaponStopEmitting()
    {
        currentWeapon?.StopEmitting();
    }
    public void ExtraVoid()
    {
        currentWeapon?.AdditonalVoid(this);
    }
    public virtual void CancelAllAttacks()
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
        noOfClicks = 0;
        WeaponStopEmitting();
    }

    
}
