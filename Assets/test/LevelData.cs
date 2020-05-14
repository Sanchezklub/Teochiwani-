using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int[,] roomRelations;

    public List<RoomData> roomRelation;
    public List<EnemyData> enemiesData;
    //public List<ItemData> itemsData;
    //public List<EnviroData> enviromentData;

    public void Start()
    {
        EventController.instance.levelEvents.OnLevelGenerated += SaveLayout;
        int[,] layout = new int[6, 4];
        layout[0, 0] = 15;
        layout[1, 1] = 20;

        //SaveLayout(layout);
    }

    public void SaveEnemies(List<EnemyHealth> currentEnemies)
    {
        enemiesData = new List<EnemyData>();

        foreach(EnemyHealth enemy in currentEnemies)
        {
            enemiesData.Add(new EnemyData(enemy.id, enemy.transform.position));
        }
    }

    public void SaveLayout(int[,] layout)
    {
        roomRelations = layout;
        roomRelation = new List<RoomData>();
        for(int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                roomRelation.Add(new RoomData(i, j, layout[i, j]));
            }
        }
    }

    public void SaveItems(/*Lista czegoś*/)
    {

    }

    public void SaveEnviro(/*Lista czegoś*/)
    {

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
    public int id;
    public Vector3 position;
}

