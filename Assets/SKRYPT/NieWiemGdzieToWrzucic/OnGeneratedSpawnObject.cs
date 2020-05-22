using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGeneratedSpawnObject : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] objects;
    void Awake()
    {
        EventController.instance.levelEvents.OnLevelGeneratedBasic += SpawnObject;
    }

    void SpawnObject()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity);
    }
}
