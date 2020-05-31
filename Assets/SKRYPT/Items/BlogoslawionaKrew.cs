using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlogoslawionaKrew : BaseItem
{
    public Collider2D coll;
    public string Itemname;
    public string FlavourText;
    public int AllStatsBuff = 10;

    public int CocaoPrice= 4;
    public int BloodPrice = 4;
    public override void PickupItem()
    {
        base.PickupItem();
        coll.enabled=false;
        Debug.Log("XD");
        Destroy(gameObject);
        /*GameController.instance.DataStorage.PlayerInfo.damage += AllStatsBuff;
        GameController.instance.DataStorage.PlayerInfo.maxhealth += AllStatsBuff;
        GameController.instance.DataStorage.PlayerInfo.currenthealth += AllStatsBuff;
        GameController.instance.DataStorage.PlayerInfo.speed += AllStatsBuff;
        GameController.instance.DataStorage.PlayerInfo.crouchspeed += AllStatsBuff;
        GameController.instance.DataStorage.PlayerInfo.jumpforce += AllStatsBuff;
        */
    }
    /*
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
        ShowFloatingText(Itemname);
        }
    }

    */
}
