using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POA : BaseWeaponCloseCombat
{

    public float Playercurrenthealth;   
    
    
    public override void DropWeapon()
    {
        base.DropWeapon();
        GameController.instance.DataStorage.PlayerInfo.currenthealth+=Playercurrenthealth-1; 
    }
    public override void PickupWepaon()
    {
        base.PickupWepaon();
        Playercurrenthealth=GameController.instance.DataStorage.PlayerInfo.currenthealth;
        GameController.instance.DataStorage.PlayerInfo.currenthealth=1;
    }
     
}