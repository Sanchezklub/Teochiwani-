using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : BaseWeapon
{
    public bool FacingRight = true;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Collider2D coll;
    public string FlavourText = "to łuk.... naprawde czego sie spodziewałeś";

   

    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Bow :: Attack() - Player attacked with bow");
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
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
        ShowFloatingText(FlavourText);

        coll.enabled = false;

        GameObject Player = GameObject.Find("Player");
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
        
    }
    
}
