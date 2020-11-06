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
        items.Add(newItem);
        if (newItem.gameObject.GetComponentInParent<CharacterController2D>() != null)
        {
            items.Remove(newItem);
        }
        Debug.LogFormat("Item Tracker :: OnNewItem - added new item {0} to the list", newItem.name);
    }

    public void OnItemDie(BaseItem item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.LogFormat("Item Tracker :: OnItemDie - removed item {0} from the list", item.name);
        }
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
