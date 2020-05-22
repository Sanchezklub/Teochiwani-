using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    
    public GameObject[] objects;

    private void Start()
    {
        int rand = Random.Range(0, objects.Length);
        if (objects.Length != 0)
        {
            Instantiate(objects[rand], transform.position, Quaternion.identity );
        }
    }
    
}
