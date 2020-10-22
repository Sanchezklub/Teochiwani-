using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public GameObject[] ChunkComponents;
    private GameObject player;
    public float distance;
    public float d2;
    
    void FixedUpdate()
    {
        player = GameObject.Find("Player");
        distance = Vector3.Distance(transform.position, player.transform.position);
        if ( distance > d2)
        {
            foreach (GameObject chunkComponents in ChunkComponents)
            {
            chunkComponents.SetActive(false);
            }
        }
        else  if ( distance < d2)
        {
            foreach (GameObject chunkComponents in ChunkComponents)
            {
            chunkComponents.SetActive(true);
            }
        }

    }
}
