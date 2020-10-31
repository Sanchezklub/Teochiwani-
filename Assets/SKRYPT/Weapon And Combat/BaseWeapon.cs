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

    //public float damage;
    public PlayerInformation info;
    [SerializeField] public bool Attacking=false;
    public int EnemyCounter;
    private bool ModifierChosen = false; //sprawdza, czy proces przebiegł, jest true nawet jak modifier jest pusty
    [SerializeField] public ParticleSystem ModifierParticle;
    [SerializeField] private BaseWeaponModifier currentModifier;
    [SerializeField] public bool EffectLightning=false;
    [SerializeField] public bool EffectGodly=false;
    [SerializeField] public bool EffectHuman=false;

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
    
    [SerializeField]public SpriteRenderer SpriteRen;
     public PolygonCollider2D pc;
    public AudioClip AttackSound;
    public AudioSource audio;
    public bool EnemyWas;
    
    
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
        SpriteRen = this.GetComponent<SpriteRenderer>();
    }
    public void SoundAttack()
    {
        AudioManager.instance.Play("Sword");
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
            if( EffectLightning)
            {
                enemy.GetComponent<Health>()?.Effect(PoisonDamage,PoisonCount,PoisonTimeBetween,3);
            }
        
    }
    public void AddParticle()
    {
        Instantiate(ModifierParticle, AttackPoint.transform.position, Quaternion.identity, transform);
    }
    public override void Start()
    {
        SpriteRen = this.GetComponent<SpriteRenderer>();
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
        IsAttackingRanged,
        IsAttackingShoot,
        IsAttackingThrow

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

            currentModifier = WeaponModDictionary.instance.GetWeaponModifier(ModId);
            currentModifier?.Apply(this);
            ModifierChosen = true;
        }

    }
    public void RemoveModifier()
    {
        if (currentModifier)
        {
            currentModifier.Remove(this);
            currentModifier = null;
        }
    }

    public void ChangeModifier(int newModId)
    {
        RemoveModifier();
        currentModifier = WeaponModDictionary.instance.GetWeaponModifier(newModId);
        currentModifier?.Apply(this);
        ModifierChosen = true;

    }
    public void AdditonalVoid(PlayerCombat controller)
    {
        controller.animator.SetBool("Reloaded", true);
    }

    public int[] EnemyId = new int [100];
    
    public void StartEnemyList()
    {
        Attacking=true;
        EnemyCounter=0;
    }


    public void ClearEnemyList()
    {
        Attacking=false;
        for (int i = 0; i < EnemyId.Length; i++)
        {
        EnemyId[i] = 0; 
        }
    }
    //private void OnDrawGizmos()
   // {
      //  Handles.Label(transform.position, ModId.ToString());
   // }
    public override void PickupWepaon()
    {
        base.PickupWepaon();
        if ( pc!=null)
        pc.enabled=true;
        if (currentModifier != null)
        {
            currentModifier.PickedUp();
        }
    }
    public virtual void DropWeapon()
    {
         base.DropWeapon();
         if ( pc!=null)
         pc.enabled=false;
        if (currentModifier != null)
        {
            currentModifier.Dropped();
        }
    }
    
}
