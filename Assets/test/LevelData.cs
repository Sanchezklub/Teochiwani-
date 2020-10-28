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
                foreach (RoomData data in roomData)
                {
                    if (CheckDifference(enemy.transform.position, data.position))
                    {
                        enemiesData.Add(new EnemyData(enemy.id, enemy.transform.position, data.roomNumber));
                        Debug.LogFormat("LevelData :: Item successfully saved. Number was {0}", data.roomNumber);
                        break;
                    }
                    else Debug.Log("Item couldn't be saved");


                }
                //enemiesData.Add(new EnemyData(enemy.id, enemy.transform.position));
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
                foreach (RoomData data in roomData)
                {
                    if (CheckDifference(enviro.transform.position, data.position))
                    {
                        enviromentData.Add(new EnviroData(enviro.id, enviro.transform.position, data.roomNumber));
                        Debug.LogFormat("LevelData :: Item successfully saved. Number was {0}", data.roomNumber);
                        break;
                    }
                    else Debug.Log("Item couldn't be saved");


                }
                //enviromentData.Add(new EnviroData(enviro.id, enviro.transform.position));
            }
        }
    }
    public void SaveWeapon(List<BaseWeapon> currentWeapon)
    {
        weaponData = new List<WeaponData>();

        foreach (BaseWeapon weapon in currentWeapon)
        {
            foreach (RoomData data in roomData)
            {
                if (CheckDifference(weapon.transform.position, data.position))
                {
                    itemData.Add(new ItemData(weapon.id, weapon.transform.parent.position, weapon.ModId, data.roomNumber));
                    Debug.LogFormat("LevelData :: Item successfully saved. Number was {0}", data.roomNumber);
                    break;
                }
                else Debug.Log("Item couldn't be saved");


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
                    foreach (RoomData data in roomData)
                    {
                        if (CheckDifference(item.transform.parent.position, data.position))
                        {
                            itemData.Add(new ItemData(item.id, item.transform.parent.position, item.ModId, data.roomNumber));
                            Debug.LogFormat("LevelData :: Item successfully saved. Number was {0}", data.roomNumber);
                            break;
                        }
                        else Debug.Log("Item couldn't be saved");
                        
                        
                    }


                }
                else
                {
                    foreach (RoomData data in roomData)
                    {
                        if (CheckDifference(item.transform.position, data.position))
                        {
                            itemData.Add(new ItemData(item.id, item.transform.parent.position, item.ModId, data.roomNumber));
                            Debug.LogFormat("LevelData :: Item successfully saved. Number was {0}", data.roomNumber);
                            break;
                        }
                        else Debug.Log("Item couldn't be saved");


                    }
                }

            }
        }
    }

    private bool CheckDifference(Vector2 objectPosition, Vector2 roomPosition)
    {
        if (objectPosition.x >= (roomPosition.x - SaveSystem.Instance.levelGen.moveAmountx) && objectPosition.x < (roomPosition.x + SaveSystem.Instance.levelGen.moveAmountx) && objectPosition.y >= (roomPosition.y - SaveSystem.Instance.levelGen.moveAmounty) && objectPosition.y < (roomPosition.y + SaveSystem.Instance.levelGen.moveAmounty))
        {
            return true;
        }
        return false;
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

        SaveSystem.Instance.roomNumbers.Clear();
        foreach (RoomId room in currentRooms)
        {
            if (room != null)
            {
                while (SaveSystem.Instance.roomNumbers.Contains(room.roomNumber) || room.roomNumber == 0)
                {
                    room.roomNumber = Random.Range(0, 100);
                    Debug.LogFormat("LevelData :: SaveRooms() - The number randomly assigned to room {0} was {1}", room.gameObject.name, room.roomNumber);
                }
                roomData.Add(new RoomData(room.id, room.transform.position, room.roomNumber));
                Debug.Log("Room was saved");
            }

        }
        Debug.LogFormat("LevelData :: RoomNumbers were {0}", SaveSystem.Instance.roomNumbers);
    }

    //Odpiąc się od eventu
}

[System.Serializable]
public class RoomData
{
    public RoomData(int id, Vector3 position, int roomNumber)
    {
        this.id = id;
        this.position = position;
        this.roomNumber = roomNumber;
    }

    public int id;
    public Vector3 position;
    public int roomNumber;
}

[System.Serializable]
public class EnviroData
{
    public EnviroData(int id, Vector3 position, int roomNumber)
    {
        this.id = id;
        this.position = position;
        this.roomNumber = roomNumber;
    }
    public int id;
    public Vector3 position;
    public int roomNumber;
}

[System.Serializable]
public class EnemyData
{
    public EnemyData(int id, Vector3 position, int roomNumber)
    {
        this.id = id;
        this.position = position;
        this.roomNumber = roomNumber;
    }

    public int id;
    public Vector3 position;
    public int roomNumber;
}

[System.Serializable]
public class ItemData
{
    public ItemData(int id, Vector3 position, int ModId, int roomNumber)
    {
        this.id = id;
        this.position = position;
        this.ModId = ModId;
        this.roomNumber = roomNumber;
    }
    public int id;
    public Vector3 position;
    public int ModId;
    public int roomNumber;
}
[System.Serializable]
public class WeaponData
{
    public WeaponData(int id, Vector3 position, int roomNumber)
    {
        this.id = id;
        this.position = position;
        this.roomNumber = roomNumber;
    }
    public int id;
    public Vector3 position;
    public int roomNumber;
}



