using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CzaszkaWrogiegoPlemienia : BaseItem
{
    public string Name="Czaszka Wrogiego Plemienia";
    public string FlavourText="Ich krew naszą siłą";
    public override void PickupItem()
    {



    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag=="Player")
        {
            ShowFloatingText(Name);
            Destroy(this, 5);
        }
    }
}
