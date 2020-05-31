using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuszaDrzewolaza : BaseItem
{
    public Collider2D coll;
    public string Itemname;
    public string FlavourText;

    public int CocaoPrice = 4;
    public int BloodPrice = 4;
    public override void PickupItem()
    {
        base.PickupItem();
        coll.enabled = false;
        Destroy(gameObject);


    }
    /*
    public override void OnTriggerEnter2D(Collider2D coll2)
    {
        base.OnTriggerEnter2D(coll2);
    }*/
}
