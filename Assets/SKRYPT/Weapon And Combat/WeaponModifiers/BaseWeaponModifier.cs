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
    [SerializeField] ParticleSystem modifierParticle;
    [SerializeField] Color TrailColor;
    [SerializeField] bool Poison;
    [SerializeField] bool Bleed;
    [SerializeField] bool Fire;
    [Range(-1.0f, 1.0f)]
    public float AttackSpeedChange;


    private int DefaultBloodPrice;
    private int DefaultCocaoPrice;
    private float DefaultAttackdamage;
    private float DefaultAttackrange;
    private ParticleSystem DefaultParticle;
    private bool DefaultFire;
    private bool DefaultBleed;
    private bool DefaultPoison;
    private string DefaultWeaponName;

    // latwo dodawac damge i effekty zostaly attackspeed
    public void Apply(BaseWeapon weapon)
    {

        StoreBaseValues(weapon);

        weapon.BloodPrice += PriceChange;
        weapon.CocaoPrice += PriceChange;
        weapon.attackdamage += DamageChange;
        weapon.attackRange += AttackRangeChange;
        weapon.ModifierParticle = modifierParticle;
        weapon.trail.startColor=TrailColor;
        if(Fire )
        {
            weapon.EffectFire = Fire;
        }
        if(Bleed)
        {
            weapon.EffectBleed = Bleed;
        }
        if(Poison)
        {
            weapon.EffectPoison = Poison;
        }
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

    public void Remove(BaseWeapon weapon)
    {
        weapon.BloodPrice = DefaultBloodPrice;
        weapon.CocaoPrice = DefaultCocaoPrice;
        weapon.attackdamage = DefaultAttackdamage;
        weapon.attackRange = DefaultAttackrange;
        weapon.ModifierParticle = DefaultParticle;
        weapon.EffectFire = DefaultFire;
        weapon.EffectBleed = DefaultBleed;
        weapon.EffectPoison = DefaultPoison;
        weapon.itemName = DefaultWeaponName;
    }

    private void StoreBaseValues(BaseWeapon weapon)
    {
        DefaultBloodPrice = weapon.BloodPrice;
        DefaultCocaoPrice = weapon.CocaoPrice;
        DefaultAttackdamage = weapon.attackdamage;
        DefaultAttackrange = weapon.attackRange;
        DefaultParticle = weapon.ModifierParticle;
        DefaultFire = weapon.EffectFire;
        DefaultBleed = weapon.EffectBleed;
        DefaultPoison = weapon.EffectPoison;
        DefaultWeaponName = weapon.itemName;


    /*public float attackdamage;
    public float attackrange;
    public ParticleSystem particle;
    public bool Fire;
    public bool Bleed;
    public bool Poison;
    public string weaponName;*/
    }
}
