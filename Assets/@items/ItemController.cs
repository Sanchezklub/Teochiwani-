using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public List<BaseItem> allItems;
    public List<int> unlockedItems;

    public List<BaseCondition> conditions;

    private void Start()
    {

        //Load
        Init();
    }

    public void Init()
    {
        foreach(var cond in conditions)
        {
            cond.Init();
        }

        CheckConditions();
    }

    /*
    public BaseItem GetPossibleItems(int count)
    {
        List<int> tempList = new List<int>();
        tempList.AddRange(SaveSystem.Instance.saveContainer.itemsData.unlockedItems);

        //usuwać element z listy 
        return null;
        
    }

    public BaseItem GetItem(int idex)
    {
        return allItems.Find(c => c.id == idex);
    }*/

    [ContextMenu("Check Conditions")]
    public void CheckConditions()
    {
        foreach (var cond in conditions)
        {
            Debug.LogFormat("Item to unlock {0} condition : {1}", cond.itemToUnlockid, cond.CheckIfConditionSucesed());

            if (cond.CheckIfConditionSucesed())
            {
                if (SaveSystem.Instance.saveContainer.itemsData.CheckIfExists(cond.itemToUnlockid))
                {
                    return;
                }

                SaveSystem.Instance.saveContainer.itemsData.AddItem(cond.itemToUnlockid);
            }
        }
    }

    private void Update()
    {
        foreach(var cond in conditions)
        {
            cond.UpdateCondition();
        }
    }

    public void OnRoundEnd()
    {
        foreach(var cond in conditions)
        {
            if (cond.CheckIfConditionSucesed())
            {
                if (SaveSystem.Instance.saveContainer.itemsData.CheckIfExists(cond.itemToUnlockid))
                    return;
                
                SaveSystem.Instance.saveContainer.itemsData.AddItem(cond.itemToUnlockid);
            }
        }
    }

    public void Deinit()
    {

    }

}
