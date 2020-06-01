using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDeleter : MonoBehaviour
{
    public GameObject LoadedObjectHolder;

    [ContextMenu("Delete")]
    public void Delete()
    {
        GameObject[] level;
        level = GameObject.FindGameObjectsWithTag("Level_generation");
        foreach (GameObject lv in level)
        {
            Destroy(lv);
        }

        foreach (Transform obj in LoadedObjectHolder.transform)
        {
            Destroy(obj.gameObject);
        }
    }
}
