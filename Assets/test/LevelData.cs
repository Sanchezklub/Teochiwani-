using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PlayerLoop;

[System.Serializable]
public class LevelData
{
    public int[,] roomRelations;

    public List<RoomData> roomData;
    public List<EnemyData> enemiesData;
    public List<EnviroData> enviromentData;
    public List<WeaponData> weaponData;
    public List<ItemData> itemData;
    //public List<>



    public void Start()
    {
        //EventController.instance.levelEvents.OnLevelGenerated += SaveLayout;
        //int[,] layout = new int[7, 4];
        //layout[0, 0] = 15;
        //layout[1, 1] = 20;

        //SaveLayout(layout);
    }

    public void SaveEnemies(List<EnemyHealth> currentEnemies)
    {
        enemiesData = new List<EnemyData>();

        foreach (EnemyHealth enemy in currentEnemies)
        {
            if(enemy != null)
            {
                enemiesData.Add(new EnemyData(enemy.id, enemy.transform.position));
            }
        }
    }
    public void SaveEnviroment(List<EnviroId> currentEnviro)
    {
        enviromentData = new List<EnviroData>();

        foreach (EnviroId enviro in currentEnviro)
        {
            if(enviro != null)
            {
                enviromentData.Add(new EnviroData(enviro.id, enviro.transform.position));
            }
        }
    }
    public void SaveWeapon(List<BaseWeapon> currentWeapon)
    {
        weaponData = new List<WeaponData>();

        foreach (BaseWeapon weapon in currentWeapon)
        {
            if (weapon != null)
            {
                weaponData.Add(new WeaponData(weapon.id, weapon.transform.position));
            }
        }
    }
    public void SaveItem(List<BaseItem> currentItem)
    {
        itemData = new List<ItemData>();

        foreach (BaseItem item in currentItem)
        {
            if (item != null)
            {
                if (item is BaseWeapon)
                {
                    itemData.Add(new ItemData(item.id, item.transform.parent.position, item.ModId));
                }
                else
                {
                    itemData.Add(new ItemData(item.id, item.transform.position, item.ModId));
                }

            }
        }
    }


    /*public void SaveLayout(int[,] layout)
    {


        roomRelations = layout;
        roomData = new List<RoomData>();
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                roomData.Add(new RoomData(i, j, layout[i, j]));
            }
        }
    }*/

    public void SaveRooms(List<RoomId> currentRooms)
    {
        roomData = new List<RoomData>();

        foreach (RoomId room in currentRooms)
        {
            if (room != null)
            {
                roomData.Add(new RoomData(room.id, room.transform.position));
            }
        }
    }

    //Odpiąc się od eventu
}

[System.Serializable]
public class RoomData
{
    public RoomData(int id, Vector3 position)
    {
        this.id = id;
        this.position = position;
    }

    public int id;
    public Vector3 position;
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
    public ItemData(int id, Vector3 position, int ModId)
    {
        this.id = id;
        this.position = position;
        this.ModId = ModId;
    }
    public int id;
    public Vector3 position;
    public int ModId;
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



