using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
using UnityEngine.Events;

public abstract class BaseWeapon : BaseItem
{
    
    [SerializeField] public LayerMask enemyLayers;
    [SerializeField] public Transform AttackPoint;
    [SerializeField] public float attackRange;
    [SerializeField] public float attackdamage;
    [SerializeField] public TrailRenderer trail;
    private bool ModifierChosen = false; //sprawdza, czy proces przebiegł, jest true nawet jak modifier jest pusty
    [SerializeField] public ParticleSystem ModifierParticle;
    [SerializeField] public bool EffectBleed=false;
    [SerializeField]public float BleedDamage;
    [SerializeField]public int BleedCount;
    [SerializeField]public float BleedTimeBetween;

    [SerializeField]public bool EffectFire=false;
    [SerializeField]public float FireDamage;
    [SerializeField]public int FireCount;
    [SerializeField]public float FireTimeBetween;

    [SerializeField] public bool EffectPoison=false;
    [SerializeField]public float PoisonDamage;
    [SerializeField]public int PoisonCount;
    [SerializeField]public float PoisonTimeBetween;
    

    public AudioClip AttackSound;
    public AudioSource audio;
    
    
    public enum SexType
    {
        Meski,
        Zenski,
        Nijaki,
        Meskoosobowy,
        Niemeskoosobowy
    }

    public SexType weaponSexType;
    public void Awake()
    {
       
        //UIFlavourText = Find("FlavourText");
        //EventController.instance.weaponEvents.CallOnWeaponAppear(this);
        GetUITexts();

    }
    public void SoundAttack()
    {
        audio.clip= AttackSound;
        audio.Play();
    }
    public void Effects(Collider2D enemy )
    {
        if ( EffectBleed == true)
            {
                enemy.GetComponent<Health>()?.Effect(BleedDamage,BleedCount,BleedTimeBetween,0);
            }
            if ( EffectFire == true)
            {
                enemy.GetComponent<Health>()?.Effect(FireDamage,FireCount,FireTimeBetween,1);
            }
            if ( EffectPoison == true)
            {
                enemy.GetComponent<Health>()?.Effect(PoisonDamage,PoisonCount,PoisonTimeBetween,2);
            }
        
    }
    public void AddParticle()
    {
        Instantiate(ModifierParticle, AttackPoint.transform.position, Quaternion.identity, transform);
    }
    public override void Start()
    {
        ChooseModifier();
        AddParticle();
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
    void ChooseModifier()
    {
        if (!ModifierChosen)
        {
            if (ModId < 0)
            {
                ModId = Random.Range(0, WeaponModDictionary.instance.WeaponModifiers.Length);
                Debug.LogFormat("Randomly chosen ModifierId for {0} was {1}", name, ModId);
            }

            BaseWeaponModifier mod = WeaponModDictionary.instance.GetWeaponModifier(ModId);
            mod?.Apply(this);
            ModifierChosen = true;
        }

    }

    private void OnDrawGizmos()
    {
        Handles.Label(transform.position, ModId.ToString());
    }


}
