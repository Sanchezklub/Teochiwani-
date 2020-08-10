using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStrzala : MonoBehaviour
{
    Rigidbody2D rb;
    PolygonCollider2D pc;
    bool hasHit;
    public int damage = 20;
    public int Range =2;
    public LayerMask Player;
    public Collider2D[] hitEnemies;
    public GameObject Tip;
    public ParticleSystem fire;
    [SerializeField]public float FireDamage;
    [SerializeField]public int FireCount;
    [SerializeField]public float FireTimeBetween;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        pc=GetComponent<PolygonCollider2D>();
        //Instantiate(fire,tip.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasHit==false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x)* Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward );
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit=true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        pc.isTrigger=true;
        hitEnemies = Physics2D.OverlapCircleAll(Tip.transform.position, Range, Player);
        foreach (Collider2D enemy in hitEnemies)         
        {
        enemy.GetComponent<Health>()?.TakeDamage(damage);
        enemy.GetComponent<Health>()?.Effect(FireDamage,FireCount,FireTimeBetween,1);
        //this.transform.position =transform.position + new Vector3(5, 0, 0);  
        this.transform.parent=enemy.transform;
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
