using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkorupaZolwia : BaseItem
{
    public Collider2D coll;
    public string Itemname="Skorupa żółwia";
    public string FlavourText="Skała chciałaby być twarda jak to";
    public int SpeedBuff=10;
        public override void PickupItem()
    {
        coll.enabled=false;
        Debug.Log("XD");
        Destroy(gameObject);
        GameController.instance.DataStorage.PlayerInfo.speed += SpeedBuff;
    }

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
        ShowFloatingText(Itemname);
        }
    }
}
