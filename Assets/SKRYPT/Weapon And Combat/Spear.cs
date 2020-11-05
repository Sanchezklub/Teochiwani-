using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spear : BaseWeapon
{
    bool hasHit;
    Vector2 direction; 
    public float LaunchForce;
    public bool flying = false;

    public Rigidbody2D rb;

    public Collider2D[] hitEnemies;
    //public ParticleSystem HitParticle;
    public void Update()
    {
        if ( PickUped&& flying==false )
        {
        rb.bodyType = RigidbodyType2D.Kinematic;    
        Vector2 bowPosition = Handle.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        Handle.transform.right=direction;
        }  
        if (flying)
        {
            if(hasHit==false)
            {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x)* Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward );
            }
        }
    
        
    }
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Spear :: Attack() - Player attacked with Spear");
        Handle.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        Handle.transform.right=direction;
        DropWeapon();
        GameController.instance.DataStorage.PlayerInfo.currentweaponID = 9999;
        GameController.instance.DataStorage.PlayerInfo.currentweaponModID = 0;
        controller.currentWeapon = null;
        PickUped=false;
        flying=true;
        rb.isKinematic = false;
        pc.enabled=true;
        coll.enabled=false;
        trail.emitting=true;
        //rb.bodyType=RigidbodyType2D=Dynamic;
        
    }
    public override void PickupWepaon()
    {
        base.PickupWepaon();
        flying=false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        pc.enabled=false;
        hasHit=false;
        trail.emitting=false;
        GameObject crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        crosshair.GetComponent<Image>().color = Color.white;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(flying && collision.gameObject.tag!="Player" && !hasHit);
        {
            hasHit=true;
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<Health>()?.TakeDamage(attackdamage+info.damage);   
            Effects(collision);
            flying=false;
            coll.enabled=true;
        }
        

        
        
    }
    public override void DropWeapon()
    {
        base.DropWeapon();
        GameObject crosshair = GameObject.FindGameObjectWithTag("Crosshair");
        crosshair.GetComponent<Image>().color = Color.clear;
    }
}
