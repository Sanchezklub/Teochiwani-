using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MieczTysiacaKrokow : BaseWeaponCloseCombat
{
    public float PlayerSpeedChange;
    public override void Attack(PlayerCombat controller)
    {
    
    }
    public override void DropWeapon()
    {
        GameController.instance.DataStorage.PlayerInfo.speed-=PlayerSpeedChange;
        base.DropWeapon();
    }
    public override void PickupWepaon()
    {
        base.PickupWepaon();
        GameController.instance.DataStorage.PlayerInfo.speed+=PlayerSpeedChange;
    }
      
}