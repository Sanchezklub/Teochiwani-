using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorozeLosia : BaseItem
{
    public Collider2D coll;
    public string Itemname;
    public string FlavourText;
    public int Damagebuff = 10;
    public int Speedbuff = 30;

    public int CocaoPrice= 4;
    public int BloodPrice = 4;
    public override void PickupItem()
    {
        base.PickupItem();
        coll.enabled=false;
        Debug.Log("XD");
        Destroy(gameObject);
        //GameController.instance.DataStorage.PlayerInfo.damage += Damagebuff;
        //GameController.instance.DataStorage.PlayerInfo.speed += Speedbuff;
    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
        ShowFloatingText(Itemname);
        }
    }
}
