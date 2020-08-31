using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChunkGenerated : MonoBehaviour
{
    public GameObject[] objects;
    void Awake()
    {
        EventController.instance.levelEvents.OnChunkGeneratedBasic += SpawnObject;
    }

    void SpawnObject()
    {
        int rand = Random.Range(0, objects.Length);
        if (objects[rand] != null && this != null)
        {
            GameObject obj = Instantiate(objects[rand], transform.position, Quaternion.identity);
            if(this.gameObject != null)
            {
                obj.transform.parent = this.gameObject.transform;
            }
        }

    }
}
