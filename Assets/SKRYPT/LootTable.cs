using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootTable : MonoBehaviour
{
    public static Sprite[] WeaponLook;
    public static BaseWeapon[] Weapon;
    public static GameObject[] WeaponSpawneable;
    public void Start()
    {
        if(Weapon.Length != WeaponLook.Length || Weapon.Length!= WeaponSpawneable.Length|| WeaponSpawneable.Length != WeaponLook.Length)
        {
            Debug.Log("Brakuje czegoś");
        }
    }
    
}
