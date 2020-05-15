using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem Instance;
    public EnviromentTracker enviromentTracker;
    public EnemyTracker enemyTracker;
    public ItemTracker itemTracker;
    public WeaponTracker weaponTracker;
   

    public SaveContainer saveContainer;

    private void Awake()
    {
        Instance = this;
        LoadGame();
    }

    private void Start()
    {
        saveContainer.levelData.Start();
    }

    public void SaveGame ()   
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream  = new FileStream(path, FileMode.Create);

        string mess = JsonUtility.ToJson(saveContainer);

        formatter.Serialize(stream, mess);
        stream.Close();

    }
    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if ( File.Exists(path))
        {
          BinaryFormatter formatter = new BinaryFormatter(); 

          FileStream stream  = new FileStream(path, FileMode.Open);

          string message = formatter.Deserialize(stream) as string;

          //Debug.Log(message);
            //PlayerDataScript data = JsonUtility.FromJson<PlayerDataScript>(message);
            saveContainer = JsonUtility.FromJson<SaveContainer>(message);
            Debug.Log(saveContainer);

          stream.Close();
            //return null;
          //return data;
        }
        else
        {
            Debug.Log("NoData");
            //return null;
        }
    }


    [ContextMenu("Test")]
    public void Test()
    {
        saveContainer.levelData.SaveItem(itemTracker.items);
        saveContainer.levelData.SaveWeapon(weaponTracker.weapons);
        saveContainer.levelData.SaveEnemies(enemyTracker.enemies);
        saveContainer.levelData.SaveEnviroment(enviromentTracker.enviros);
    }

    private void OnApplicationQuit()
    {
        saveContainer.levelData.SaveItem(itemTracker.items);
        saveContainer.levelData.SaveWeapon(weaponTracker.weapons);
        saveContainer.levelData.SaveEnemies(enemyTracker.enemies);
        saveContainer.levelData.SaveEnviroment(enviromentTracker.enviros);
        saveContainer.playerData = new PlayerDataScript(GameController.instance.DataStorage.PlayerInfo);

        SaveGame();
    }
}
