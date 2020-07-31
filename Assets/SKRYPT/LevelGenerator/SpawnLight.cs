using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLight : MonoBehaviour
{
    public GameObject[] Lights;
    
    void Start()
    {
        if (transform.position.y < -10 )
        {
            Instantiate(Lights[Random.Range(0, Lights.Length)],transform.position, Quaternion.identity );
        }
    }

    
}
