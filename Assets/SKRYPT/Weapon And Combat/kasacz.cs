using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kasacz : BaseWeapon
{
    public bool FacingRight = true;
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    public Collider2D coll;
    public string FlavourText = "tak toksyczny jak użytkownik";

    public float attackRange;
    public float attackdamage;

    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("kasacz :: Attack() - Player attacked with kasacz");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage);

        }
    }

      public override void DropWeapon()
    {
<<<<<<< Updated upstream
        GameObject Player = GameObject.Find("Player");
        CharacterController2D zwrot = Player.GetComponent<CharacterController2D>();
        FacingRight = zwrot.m_FacingRight;
        if (FacingRight == true)
        {
           Debug.Log("right");
        }
        else
        {
            Debug.Log("left");
            transform.Rotate(0f,180f,0f);
        }
        transform.parent = null;
=======
                
        
        Handle.transform.parent = null;
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
>>>>>>> Stashed changes
        coll.enabled = true;
    }

    public override void PickupWepaon()
    {   
        ShowFloatingText(FlavourText);
        
        coll.enabled = false;

        GameObject Player = GameObject.Find("Player");
        CharacterController2D zwrot = Player.GetComponent<CharacterController2D>();
        FacingRight = zwrot.m_FacingRight;
        if (FacingRight == true)
        {
            //chuj
        }
        else
        {
            transform.Rotate(0f,180f,0f);
        }
    }
    
}