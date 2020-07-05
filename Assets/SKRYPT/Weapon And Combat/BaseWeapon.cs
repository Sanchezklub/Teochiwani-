using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public abstract class BaseWeapon : BaseItem
{
    
    [SerializeField] public LayerMask enemyLayers;
    [SerializeField] public Transform AttackPoint;
    [SerializeField] public float attackRange;
    [SerializeField] public float attackdamage;
    public void Awake()
    {
       
        //UIFlavourText = Find("FlavourText");
        EventController.instance.weaponEvents.CallOnWeaponAppear(this);
        GetUITexts();

    }

    public void GetUITexts()
    {
        UIFlavorText = GameObject.FindGameObjectWithTag("FlavorText")?.GetComponentInChildren<TextMeshProUGUI>(true);
        UIWeaponName = GameObject.FindGameObjectWithTag("WeaponName")?.GetComponentInChildren<TextMeshProUGUI>(true);
    }

    public enum AnimationType
    {
        IsAttackingVLight,
        IsAttackingLight,
        IsAttackingHeavy,
        IsAttackingVHeavy,
        IsAttackingRanged
    }
    public AnimationType AttackAnimationType;
    public abstract void Attack(PlayerCombat controller);
    
    
}
