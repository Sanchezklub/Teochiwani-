using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int[,] roomRelations;
    public LevelGeneration levelGen;

    public List<RoomData> roomRelation;
    public List<EnemyData> enemiesData;
    public List<EnviroData> enviromentData;
    public List<WeaponData> weaponData;
    public List<ItemData> itemData;



    public void Start()
    {
        EventController.instance.levelEvents.OnLevelGenerated += SaveLayout;
        int[,] layout = new int[7, 4];
        //layout[0, 0] = 15;
        //layout[1, 1] = 20;

        //SaveLayout(layout);
    }

    public void SaveEnemies(List<EnemyHealth> currentEnemies)
    {
        enemiesData = new List<EnemyData>();

        foreach (EnemyHealth enemy in currentEnemies)
        {
            enemiesData.Add(new EnemyData(enemy.id, enemy.transform.position));
        }
    }
    public void SaveEnviroment(List<EnviroId> currentEnviro)
    {
        enviromentData = new List<EnviroData>();

        foreach (EnviroId enviro in currentEnviro)
        {
            enviromentData.Add(new EnviroData(enviro.id, enviro.transform.position));
        }
    }
    public void SaveWeapon(List<BaseWeapon> currentWeapon)
    {
        weaponData = new List<WeaponData>();

        foreach (BaseWeapon weapon in currentWeapon)
        {
            weaponData.Add(new WeaponData(weapon.id, weapon.transform.position));
        }
    }
    public void SaveItem(List<BaseItem> currentItem)
    {
        itemData = new List<ItemData>();

        foreach (BaseItem item in currentItem)
        {
            itemData.Add(new ItemData(item.id, item.transform.position));
        }
    }


    public void SaveLayout(int[,] layout)
    {
        Debug.Log("SavedLayout");


        roomRelations = layout;
        roomRelation = new List<RoomData>();
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                roomRelation.Add(new RoomData(i, j, layout[i, j]));
            }
        }
    }


    //Odpiąc się od eventu
}

[System.Serializable]
public class RoomData
{
    public RoomData(int x, int y, int roomIndex)
    {
        this.x = x;
        this.y = y;
        this.roomIndex = roomIndex;
    }

    public int x;
    public int y;
    public int roomIndex;
}

[System.Serializable]
public class EnviroData
{
    public EnviroData(int id, Vector3 position)
    {
        this.id = id;
        this.position = position;
    }
    public int id;
    public Vector3 position;
}

[System.Serializable]
public class EnemyData
{
    public EnemyData(int id, Vector3 position)
    {
        this.id = id;
        this.position = position;
    }

    public int id;
    public Vector3 position;
}

[System.Serializable]
public class ItemData
{
    public ItemData(int id, Vector3 position)
    {
        this.id = id;
        this.position = position;
    }
    public int id;
    public Vector3 position;
}
[System.Serializable]
public class WeaponData
{
    public WeaponData(int id, Vector3 position)
    {
        this.id = id;
        this.position = position;
    }
    public int id;
    public Vector3 position;
}



