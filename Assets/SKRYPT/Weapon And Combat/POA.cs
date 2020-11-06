using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POA : BaseWeaponCloseCombat
{

    public float Playercurrenthealth;   
    
    
    public override void DropWeapon()
    {
        base.DropWeapon();
        info.currenthealth+=Playercurrenthealth-1; 
    }
    public override void PickupWepaon()
    {
        base.PickupWepaon();
        Playercurrenthealth=info.currenthealth;
        info.currenthealth=1;
    }
     
}