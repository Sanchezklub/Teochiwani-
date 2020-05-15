using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTracker : MonoBehaviour
{
    public List<BaseWeapon> weapons  = new List<BaseWeapon>();

    public void Awake()
    {
        EventController.instance.weaponEvents.OnWeaponAppear += OnNewWeapon;
        EventController.instance.weaponEvents.OnWeaponDied += OnWeaponDie;
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

    private void OnApplicationQuit()
    {
        EventController.instance.weaponEvents.OnWeaponAppear -= OnNewWeapon;
        EventController.instance.weaponEvents.OnWeaponDied -= OnWeaponDie;
    }
}
