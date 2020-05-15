using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTracker : MonoBehaviour
{
    public List<BaseItem> items  = new List<BaseItem>();

    public void Awake()
    {
        EventController.instance.itemEvents.OnItemAppear += OnNewItem;
        EventController.instance.itemEvents.OnItemDied += OnItemDie;
    }

    public void OnNewItem(BaseItem newItem)
    {
        Debug.Log("NewItem");
        items.Add(newItem);
    }

    public void OnItemDie(BaseItem item)
    {
        items.Remove(item);
    }

    private void OnApplicationQuit()
    {
        EventController.instance.itemEvents.OnItemAppear -= OnNewItem;
        EventController.instance.itemEvents.OnItemDied -= OnItemDie;
    }
}
