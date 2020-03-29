using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{   
    string flavourtext;
    string Name;
    public GameObject FloatingTextPrefab;
    public abstract void PickupItem();
    public virtual void ShowFloatingText( string flavourtext)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = flavourtext;


    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
            ShowFloatingText(Name);
            Destroy(this, 5);
        }
    }
    public virtual void BuffJumpHeight(int JumpHeigt)
    {

    }
    public virtual void BuffAttackDamage(int Damage)
    {

    }
    public virtual void BuffHealth(int Health)
    {

    }

}
