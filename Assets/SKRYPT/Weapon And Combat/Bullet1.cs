using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D pc;
    bool hasHit;
    bool Poison=false;
    bool Bleed=false;
    bool Fire=false;
    bool Lightning = false;
    bool Godly = false;
    bool Human = false; 
    bool Vampiric = false; 

    float BleedDamage;
    int BleedCount;
    float BleedTimeBetween;

    float FireDamage;
    int FireCount;
    float FireTimeBetween;

    float PoisonDamage;
    int PoisonCount;
    float PoisonTimeBetween;


    public float damage;
    public int Range =2;

    public LayerMask Enemy;
    GameObject player;
    public Collider2D[] hitEnemies;
    public GameObject Tip;
    public ParticleSystem[] Effect; 
    public GameObject firelight;
    public BaseWeapon weapon;
    
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        pc=GetComponent<BoxCollider2D>();
        //player = GameObject.FindGameObjectWithTag("Player");
        //var weapon = player.GetComponentInChildren<BaseWeapon>();
        damage = weapon.attackdamage;
       // damage+= weapon.info.damage;
        this.GetComponent<SpriteRenderer>().material= weapon.SpriteRen.material;

        Poison = weapon.EffectPoison;
        Fire = weapon.EffectFire;
        Bleed = weapon.EffectBleed;
        Lightning = weapon.EffectLightning;
        Human = weapon.EffectHuman;
        Godly = weapon.EffectGodly;
        Vampiric = weapon.Vampiric;

        BleedDamage = weapon.BleedDamage;
        BleedCount = weapon.BleedCount;
        BleedTimeBetween = weapon.BleedTimeBetween;

        FireDamage = weapon.FireDamage;
        FireCount = weapon.FireCount;
        FireTimeBetween =   weapon.FireTimeBetween;

        PoisonDamage =weapon.PoisonDamage;
        PoisonCount = weapon.PoisonCount;
        PoisonTimeBetween =weapon.PoisonTimeBetween;

        if(weapon.EffectPoison)
        {
            Instantiate(Effect[2],Tip.transform.position, Quaternion.identity,transform);
        }
        if(weapon.EffectFire)    
        {
            Instantiate(Effect[1],Tip.transform.position, Quaternion.identity,transform);
            firelight.SetActive(true);
        }
        if(Bleed)   
        {
            Instantiate(Effect[0],Tip.transform.position, Quaternion.identity,transform);
        }

        Enemy = weapon.enemyLayers;
    }

    // Update is called once per frame
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit=true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        pc.isTrigger=true;
        hitEnemies = Physics2D.OverlapCircleAll(Tip.transform.position, Range, Enemy);
        foreach (Collider2D enemy in hitEnemies)         
        {
        enemy.GetComponent<Health>()?.TakeDamage(damage);
        
        if ( Bleed)
        {
            enemy.GetComponent<Health>()?.Effect(BleedDamage,BleedCount,BleedTimeBetween,0);
        }
        
        if ( Fire)
        {
            enemy.GetComponent<Health>()?.Effect(FireDamage,FireCount,FireTimeBetween,1);
        }
        if ( Poison)
        {
            enemy.GetComponent<Health>()?.Effect(PoisonDamage,PoisonCount,PoisonTimeBetween,2);
        }
        if( Lightning)
        {
                enemy.GetComponent<Health>()?.Effect(PoisonDamage,PoisonCount,PoisonTimeBetween,3);
        }
        if (Vampiric )
        {
            EventController.instance.playerEvents.CallOnPlayerDealDamage(damage);
        }
        
        this.transform.parent=enemy.transform;
        Destroy(gameObject, 10);
        }
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
	{   if(hasHit==false)
		{
            hitInfo.GetComponent<Health>()?.TakeDamage(damage);
            this.transform.parent = hitInfo.transform;
            hasHit=true;
        }
	}
}
