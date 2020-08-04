using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeaponModifier : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] int PriceChange;
    [SerializeField] float DamageChange;
    [SerializeField] float AttackRangeChange;
    [SerializeField] string NameChange;
    public void Apply(BaseWeapon weapon)
    {
        weapon.BloodPrice += PriceChange;
        weapon.CocaoPrice += PriceChange;
        weapon.attackdamage += DamageChange;
        weapon.attackRange += AttackRangeChange;
        weapon.itemName = NameChange +" "+ weapon.itemName;
    }
}
