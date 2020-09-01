using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemTracker : MonoBehaviour
{
    public List<BaseItem> items  = new List<BaseItem>();

    public void Start()
    {
        EventController.instance.itemEvents.OnItemAppear += OnNewItem;
        EventController.instance.itemEvents.OnItemDied += OnItemDie;
    }

    public void OnNewItem(BaseItem newItem)
    {
        //Debug.Log("NewItem");
        items.Add(newItem);
    }

    public void OnItemDie(BaseItem item)
    {
        items.Remove(item);
    }

    private void OnApplicationQuit()
    {
        if (EventController.instance != null)
        {
            EventController.instance.itemEvents.OnItemAppear -= OnNewItem;
            EventController.instance.itemEvents.OnItemDied -= OnItemDie;
        }
    }
}
