using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maczuga : BaseWeapon
{
    public bool FacingRight = true;
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    public Collider2D coll;

    public float attackRange;
    public float attackdamage;

    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("maczuga :: Attack() - Player attacked with maczuga");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>()?.TakeDamage(attackdamage);

        }
    }

      public override void DropWeapon()
    {
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
        coll.enabled = true;
    }

    public override void PickupWepaon()
    {
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