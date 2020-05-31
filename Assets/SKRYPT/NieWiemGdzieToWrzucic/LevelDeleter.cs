using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDeleter : MonoBehaviour
{
    [ContextMenu("Delete")]
    void Delete()
    {
        GameObject[] level;
        level = GameObject.FindGameObjectsWithTag("Level_generation");
        foreach (GameObject lv in level)
        {
            Destroy(lv);
        }
    }
}
