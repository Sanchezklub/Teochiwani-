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
    public ID_dictionary Dictionary;

    public LevelGeneration levelGen;

    //public LevelGeneration levelGen;


    public bool SpawnStuff = false;


    public SaveContainer saveContainer;

    public GameObject LoadedObjectHolder;
    public GameObject MainMenu;

    private void Awake()
    {
        Instance = this;
        //LoadGame();
    }

    private void Start()
    {
        saveContainer.levelData.Start();
    }

    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        string mess = JsonUtility.ToJson(saveContainer);

        formatter.Serialize(stream, mess);
        stream.Close();

    }
    public void LoadGame()
    {
        GameController.instance.DataStorage.PlayerInfo.ItemIDs.Clear();
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            string message = formatter.Deserialize(stream) as string;

            Debug.Log(message);
            PlayerDataScript data = JsonUtility.FromJson<PlayerDataScript>(message);
            saveContainer = JsonUtility.FromJson<SaveContainer>(message);
            Debug.Log(saveContainer);
            if (SpawnStuff == true)
            {
                LoadEnemies(saveContainer);
                LoadWeapons(saveContainer);
                LoadItems(saveContainer);
                LoadEnvironment(saveContainer);
                LoadRooms(saveContainer);
                LoadPlayer(saveContainer);
            }

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

    public void LoadEnemies(SaveContainer LoadedSaveContainer)
    {
        foreach (EnemyData loadedEnemy in LoadedSaveContainer.levelData.enemiesData)
        {
            GameObject EnemyPrefab = Dictionary.GetEnemyObjects(loadedEnemy.id);
            if (EnemyPrefab != null)
            {
                GameObject enemy = Instantiate(EnemyPrefab, loadedEnemy.position, Quaternion.identity);
                enemy.transform.parent = LoadedObjectHolder.transform;
            }
        }
    }

    public void LoadItems(SaveContainer LoadedSaveContainer)
    {
        foreach (ItemData loadedItem in LoadedSaveContainer.levelData.itemData)
        {
            GameObject ItemPrefab = Dictionary.GetItemObjects(loadedItem.id);
            if (ItemPrefab != null)
            {
                GameObject item = Instantiate(ItemPrefab, loadedItem.position, Quaternion.identity);
                item.transform.parent = LoadedObjectHolder.transform;
            }
        }
    }
    public void LoadWeapons(SaveContainer LoadedSaveContainer)
    {
        foreach (WeaponData loadedWeapon in LoadedSaveContainer.levelData.weaponData)
        {
            Debug.Log("Weapons id was "+loadedWeapon.id);
            GameObject WeaponPrefab = Dictionary.GetWeaponObjects(loadedWeapon.id);
            if (WeaponPrefab != null)
            {
                GameObject weapon = Instantiate(WeaponPrefab, loadedWeapon.position, Quaternion.identity);
                weapon.transform.parent = LoadedObjectHolder.transform;
            }
        }
    }
    public void LoadEnvironment(SaveContainer LoadedSaveContainer)
    {
        foreach (EnviroData loadedEnvironment in LoadedSaveContainer.levelData.enviromentData)
        {
            GameObject EnviroPrefab = Dictionary.GetEnviroObjects(loadedEnvironment.id);
            if (EnviroPrefab != null)
            {
                GameObject enviro = Instantiate(EnviroPrefab, loadedEnvironment.position, Quaternion.identity);
                enviro.transform.parent = LoadedObjectHolder.transform;
            }
        }
    }

    public void LoadRooms(SaveContainer LoadedSaveContainer)
    {
        foreach (RoomData RoomRelation in LoadedSaveContainer.levelData.roomRelation)
        {
            Debug.Log(levelGen.rooms.Length);

            if (RoomRelation.roomIndex < levelGen.rooms.Length)
            {
                GameObject RoomPrefab = levelGen.rooms[RoomRelation.roomIndex];
                Instantiate(RoomPrefab, new Vector2(levelGen.StartingPosition.x + (RoomRelation.x-1) * levelGen.moveAmountx, levelGen.StartingPosition.y + (RoomRelation.y-1) * levelGen.moveAmounty), Quaternion.identity);
            }
        }
    }

    public void LoadPlayer(SaveContainer LoadedSaveContainer)
    {
        foreach (int ItemID in LoadedSaveContainer.playerData.ItemIDs)
        {
            GameObject ItemPrefab = Dictionary.GetItemObjects(ItemID);
            GameObject item = Instantiate(ItemPrefab, new Vector3(0, 0, 100), Quaternion.identity);
            item.GetComponent<BaseItem>()?.PickupItem();
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (LoadedSaveContainer.playerData.currentweaponID < Dictionary.WeaponObjects.Length)
        {
            GameObject CurrentWeapon = Dictionary.GetWeaponObjects(LoadedSaveContainer.playerData.currentweaponID);
            GameObject Weapon = Instantiate(CurrentWeapon, new Vector2(0, 0), Quaternion.identity);
            BaseWeapon weap = Weapon.GetComponentInChildren<BaseWeapon>();
            if (weap != null)
            {
                weap.Start();
                player.GetComponent<PlayerCombat>()?.ChangeWeapon(weap);
            }
            else
            {
                Debug.Log("weap was null");
            }
        }
        else
        {
            player.GetComponent<PlayerCombat>()?.currentWeapon?.DropWeapon();
            Debug.Log("Dropped weapon");
        }

        Vector3 pos = LoadedSaveContainer.playerData.PlayerPosition;
        Debug.Log("LoadedPosition was" +pos);
        player.transform.position = LoadedSaveContainer.playerData.PlayerPosition;
    }


    [ContextMenu("Test")]
    public void FullySaveGame()
    {
        saveContainer.levelData.SaveItem(itemTracker.items);
        saveContainer.levelData.SaveWeapon(weaponTracker.weapons);
        saveContainer.levelData.SaveEnemies(enemyTracker.enemies);
        saveContainer.levelData.SaveEnviroment(enviromentTracker.enviros);
        saveContainer.playerData = new PlayerDataScript(GameController.instance.DataStorage.PlayerInfo);


        SaveGame();
    }

    private void OnApplicationQuit()
    {
        if (!MainMenu.activeSelf)
        {
            FullySaveGame();
            Debug.Log("Shutdown");
        }

    }
}
