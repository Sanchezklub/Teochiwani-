using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeaponModifier : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] int PriceChange;
    [SerializeField] float DamageChange;
    [SerializeField] float AttackRangeChange;
    [SerializeField] string MeskiNameChange;
    [SerializeField] string ZenskiNameChange;
    [SerializeField] string NijakiNameChange;
    [SerializeField] string MeskoosobowyNameChange;
    [SerializeField] string NiemeskoosobowyNameChange;
    [SerializeField] bool Poison;
    [SerializeField] bool Bleed;
    [SerializeField] bool Fire;
    [Range(-1.0f, 1.0f)]
    public float AttackSpeedChange;
    // latwo dodawac damge i effekty zostaly attackspeed
    public void Apply(BaseWeapon weapon)
    {
        weapon.BloodPrice += PriceChange;
        weapon.CocaoPrice += PriceChange;
        weapon.attackdamage += DamageChange;
        weapon.attackRange += AttackRangeChange;
        weapon.EffectFire = Fire;
        weapon.EffectBleed = Bleed;
        weapon.EffectPoison = Poison;
        weapon.AttackSpeedModifier += AttackSpeedChange; 
        switch (weapon.weaponSexType)
        {
            case BaseWeapon.SexType.Meski:
                weapon.itemName = MeskiNameChange + " " + weapon.itemName;
                break;
            case BaseWeapon.SexType.Zenski:
                weapon.itemName = ZenskiNameChange + " " + weapon.itemName;
                break;
            case BaseWeapon.SexType.Nijaki:
                weapon.itemName = NijakiNameChange + " " + weapon.itemName;
                break;
            case BaseWeapon.SexType.Meskoosobowy:
                weapon.itemName = MeskoosobowyNameChange + " " + weapon.itemName;
                break;
            case BaseWeapon.SexType.Niemeskoosobowy:
                weapon.itemName = NiemeskoosobowyNameChange + " " + weapon.itemName;
                break;

        }
        //weapon.itemName = NameChange +" "+ weapon.itemName;
    }
}
