using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodejrzanyGrzyb : BaseItem
{
    public Collider2D coll;
    public string Itemname="Podejrzany Grzyb";
    public string FlavourText="Jednorożce nie chcą przestać...";
    public int MaxHealthBuff=10;
    public int CurrentHealthBuff=10;

    public int CocaoPrice= 4;
    public int BloodPrice = 4;
    public override void PickupItem()
    {
        coll.enabled=false;
        Debug.Log("XD");
        Destroy(gameObject);
        GameController.instance.DataStorage.PlayerInfo.maxhealth += MaxHealthBuff;
        GameController.instance.DataStorage.PlayerInfo.currenthealth += CurrentHealthBuff;
    }

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
        ShowFloatingText(Itemname);
        }
    }
}
