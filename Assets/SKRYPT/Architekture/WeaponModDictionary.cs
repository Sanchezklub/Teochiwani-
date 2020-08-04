using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModDictionary : MonoBehaviour
{
    public static WeaponModDictionary instance;

    private void Awake()
    {
        instance = this;
    }

    public BaseWeaponModifier[] WeaponModifiers;
    public BaseWeaponModifier GetWeaponModifier(int id)
    {
        return WeaponModifiers[id];
    }
}
