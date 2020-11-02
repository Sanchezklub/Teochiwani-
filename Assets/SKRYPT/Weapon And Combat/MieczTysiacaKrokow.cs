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
        info.speed-=PlayerSpeedChange;
        base.DropWeapon();
    }
    public override void PickupWepaon()
    {
        base.PickupWepaon();
        info.speed+=PlayerSpeedChange;
    }
      
}