using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    public List<GameObject> ChunkComponents;
    private GameObject player;
    public float distance;
    public float d2;
    private bool IsLoaded = true;
    private void Start()
    {
        player = GameObject.Find("Player");

    }
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if ( distance > d2 && IsLoaded == true)
        {
            GetAllChildren();
            foreach (GameObject chunkComponents in ChunkComponents)
            {
                chunkComponents.SetActive(false);
                IsLoaded = false;
            }
        }
        else  if ( distance < d2 && !IsLoaded)
        {
            GetAllChildren();
            foreach (GameObject chunkComponents in ChunkComponents)
            {
                chunkComponents.SetActive(true);
                IsLoaded = true;
            }
        }

    }
    void GetAllChildren()
    {
        ChunkComponents.Clear();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            ChunkComponents.Add(transform.GetChild(i).gameObject);
        }
    }
}
