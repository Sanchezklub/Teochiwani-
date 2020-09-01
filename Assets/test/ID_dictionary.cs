using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID_dictionary : MonoBehaviour
{
    public GameObject[] EnemyObjects;

    public GameObject GetEnemyObjects(int id)
    {
        if (id < EnemyObjects.Length && id >= 0)
        {
            return EnemyObjects[id];

        }
        else
        {
            return null;
        }

    }

    public GameObject[] WeaponObjects;

    public GameObject GetWeaponObjects(int id)
    {
        if (id < WeaponObjects.Length && id >= 0)
        {
            return WeaponObjects[id];
        }
        else
        {
            return null;
        }
        

    }

    public GameObject[] ItemObjects;

    public GameObject GetItemObjects(int id)
    {
        if (id < ItemObjects.Length && id >= 0)
        {
            Debug.LogFormat("Id was {0}", id);
            return ItemObjects[id];
        }

        else
        {
            return null;
        }

    }

    public GameObject[] EnviroObjects;

    public GameObject GetEnviroObjects(int id)
    {
        if (id < EnviroObjects.Length && id >= 0)
        {
            return EnviroObjects[id];
        }
        else
        {
            return null;
        }

    }

    public GameObject[] RoomObjects;

    public GameObject GetRoomObjects(int id)
    {
        if (id < RoomObjects.Length && id >= 0)
        {
            return RoomObjects[id];
        }
        else
        {
            return null;
        }

    }


}
