using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    public BaseModifier modifier;
    private string flavourtext;
    private string itemName;
    public GameObject FloatingTextPrefab;

    public virtual void PickupItem()
    {
        //MeteorMod
        EventController.instance.playerEvents.OnItemPickup(this);
    }

    public virtual void ShowFloatingText(string flavourtext)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
        go.GetComponent<TextMesh>().text = flavourtext;


    }
    public virtual void OnTriggerEnter2D(Collider2D coll2)
    {
        if (coll2.tag == "Player")
        {
            ShowFloatingText(itemName);
            //Destroy(this, 5);
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
