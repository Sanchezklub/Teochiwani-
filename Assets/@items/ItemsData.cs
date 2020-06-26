using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemsData
{
    public List<int> unlockedItems;

    public bool CheckIfExists(int id)
    {
        return unlockedItems.Contains(id);
    }

    public void AddItem(int index)
    {
        unlockedItems.Add(index);
    }
}
