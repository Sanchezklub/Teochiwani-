using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoczystaLarwa : BaseItem
{
    public Collider2D coll;
    public string Itemname;
    public string FlavourText;
    public int MaxHealthBuff = 10;

    public int CocaoPrice= 6;
    public int BloodPrice = 2;
    public override void PickupItem()
    {
        coll.enabled=false;
        Debug.Log("XD");
        Destroy(gameObject);
        GameController.instance.DataStorage.PlayerInfo.maxhealth += MaxHealthBuff;
        GameController.instance.DataStorage.PlayerInfo.currenthealth += MaxHealthBuff;
    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
        ShowFloatingText(Itemname);
        }
    }
}
