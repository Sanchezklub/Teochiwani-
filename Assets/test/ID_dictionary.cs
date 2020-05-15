using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_dictionary : MonoBehaviour
{
    public GameObject[] EnemyObjects;

    public GameObject GetEnemyObjects(int id)
    {
        return EnemyObjects[id];

    }

    public GameObject[] WeaponObjects;

    public GameObject GetWeaponObjects(int id)
    {
        return WeaponObjects[id];

    }

    public GameObject[] ItemObjects;

    public GameObject GetItemObjects(int id)
    {
        return ItemObjects[id];

    }

    public GameObject[] EnviroObjects;

    public GameObject GetEnviroObjects(int id)
    {
        return EnviroObjects[id];

    }
}
