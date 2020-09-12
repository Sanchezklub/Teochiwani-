using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Altar : MonoBehaviour
{
     [SerializeField] private bool WeaponsOnly = false;
    int rand;
    bool Open=false;
    private void Start()
    {
        
        EventController.instance.enemyEvents.OnBossDiedBasic += Spawn;
    }
    private void Spawn()
    {
        if(Open==false)
        {
         Debug.Log("Loot");
        rand = Random.Range(0, SaveSystem.Instance.saveContainer.itemsData.unlockedItems.Count);
        Debug.Log(SaveSystem.Instance.saveContainer.itemsData.unlockedItems[rand]);
        if (WeaponsOnly)
        {
            while(SaveSystem.Instance.saveContainer.itemsData.unlockedItems[rand] < 100)
            {
                rand = Random.Range(0, SaveSystem.Instance.saveContainer.itemsData.unlockedItems.Count);
                Debug.Log(SaveSystem.Instance.saveContainer.itemsData.unlockedItems[rand]);
            }
        }
        GameObject loot = Instantiate(SaveSystem.Instance.Dictionary.ItemObjects[SaveSystem.Instance.saveContainer.itemsData.unlockedItems[rand]], new Vector2(transform.position.x, transform.position.y + 7), Quaternion.identity );
        loot.transform.parent = this.transform.parent;
        Open=true;
        }
    }
}
