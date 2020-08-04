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
    [SerializeField] private TrailRenderer trail;
    private bool ModifierChosen = false; //sprawdza, czy proces przebiegł, jest true nawet jak modifier jest pusty
    public void Awake()
    {
       
        //UIFlavourText = Find("FlavourText");
        //EventController.instance.weaponEvents.CallOnWeaponAppear(this);
        GetUITexts();

    }

    public override void Start()
    {
        ChooseModifier();
        base.Start();
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
    
    public void StartEmitting()
    {
        if (trail != null)
        {
            trail.emitting = true;
        }
    }

    public void StopEmitting()
    {
        if (trail != null)
        {
            trail.emitting = false;
        }
    }
    void ChooseModifier(bool IsLoaded = false)
    {
        Debug.Log("ModifierChosen");
        if (!ModifierChosen)
        {
            if (!IsLoaded)
            {
                ModId = Random.Range(0, WeaponModDictionary.instance.WeaponModifiers.Length);
                
            }

            BaseWeaponModifier mod = WeaponModDictionary.instance.GetWeaponModifier(ModId);
            mod?.Apply(this);
            ModifierChosen = true;
        }

    }

    
}
