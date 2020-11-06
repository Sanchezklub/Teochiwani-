using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOnChunkGenerated : MonoBehaviour
{
    public GameObject[] objects;
    void Awake()
    {
        EventController.instance.levelEvents.OnChunkGeneratedBasic += SpawnObject;
    }

    void SpawnObject()
    {
        switch (GameController.instance.DataStorage.PlayerInfo.level)
        {
            case 0:
                int rand = Random.Range(0, 2);
                GameObject obj = Instantiate(objects[rand], transform.position, Quaternion.identity);
                if (this.gameObject != null)
                {
                    obj.transform.parent = this.gameObject.transform;
                }
                break;
            case 1:
                GameObject obj1 = Instantiate(objects[3], transform.position, Quaternion.identity);
                if (this.gameObject != null)
                {
                    obj1.transform.parent = this.gameObject.transform;
                }
                break;
            case 2:
                GameObject obj2 = Instantiate(objects[2], transform.position, Quaternion.identity);
                if (this.gameObject != null)
                {
                    obj2.transform.parent = this.gameObject.transform;
                }
                break;
        }

    }
    private void OnDestroy()
    {
        EventController.instance.levelEvents.OnChunkGeneratedBasic -= SpawnObject;
    }
}
