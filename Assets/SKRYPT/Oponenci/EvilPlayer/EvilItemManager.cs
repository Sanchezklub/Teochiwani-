using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilItemManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach( int id in GameController.instance.DataStorage.EvilPlayerInfo.ItemIDs)
        {
            GameObject obj = GameObject.Instantiate(SaveSystem.Instance.Dictionary.GetItemObjects(id), transform.position, Quaternion.identity);
            EventController.instance.evilPlayerEvents.CallOnItemPickup(obj.GetComponent<BaseItem>());
            Destroy(obj);
        }
    }
}
