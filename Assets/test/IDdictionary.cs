using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDdictionary : MonoBehaviour
{
    public GameObject[] EnemyObjects;

    public GameObject GetEnemyObjects(int id)
    {
        return EnemyObjects[id];

    }
}
