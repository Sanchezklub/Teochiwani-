using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public abstract void Attack(PlayerCombat controller);
    public abstract void PickupWepaon();
    public abstract void DropWeapon();
}
