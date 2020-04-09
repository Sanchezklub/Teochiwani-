﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodensword : BaseWeapon
{
    public bool FacingRight = true;
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    public Collider2D coll;
    public string FlavourText = "zachodnia technologia, wshodnie wykonanie";
    public float attackRange;
    public float attackdamage;

    public int CocaoPrice= 5;
    public int BloodPrice = 5;

    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("WoodenSword :: Attack() - Player attacked with WoodenSword");

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
        Handle.transform.parent = null;
        
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
        coll.enabled = true;
    }

    public override void PickupWepaon()
    {
        coll.enabled = false;
        ShowFloatingText(FlavourText);
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