using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponTracker : MonoBehaviour
{
    public List<BaseWeapon> weapons  = new List<BaseWeapon>();

    public void Start()
    {
        EventController.instance.weaponEvents.OnWeaponAppear += OnNewWeapon;
        EventController.instance.weaponEvents.OnWeaponDied += OnWeaponDie;
        EventController.instance.weaponEvents.OnWeaponPickup += OnWeaponPickup;
    }

    public void OnNewWeapon(BaseWeapon newWeapon)
    {
        Debug.Log("NewWeapon");
        weapons.Add(newWeapon);
    }

    public void OnWeaponDie(BaseWeapon weapon)
    {
        weapons.Remove(weapon);
    }

    public void OnWeaponPickup(BaseWeapon oldWeapon, BaseWeapon newWeapon)
    {
        weapons.Add(oldWeapon);
        weapons.Remove(newWeapon);
    }

    private void OnApplicationQuit()
    {
        EventController.instance.weaponEvents.OnWeaponAppear -= OnNewWeapon;
        EventController.instance.weaponEvents.OnWeaponDied -= OnWeaponDie;
        EventController.instance.weaponEvents.OnWeaponPickup -= OnWeaponPickup;
    }
}
