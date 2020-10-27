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
    public RoomTracker roomTracker;
    public ID_dictionary Dictionary;

    public ItemController itemDataController;

    public LevelGeneration levelGen;

    //public LevelGeneration levelGen;


    public bool SpawnStuff = false;


    public SaveContainer saveContainer;

    [SerializeField] GameObject LoadedEnemiesHolder;
    [SerializeField] GameObject LoadedEnvirosHolder;
    [SerializeField] GameObject LoadedRoomsHolder;
    [SerializeField] GameObject LoadedItemsHolder;
    public GameObject MainMenu;

    public GameObject EvilPlayer;

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

        //Debug.LogFormat("Saved game at {0}. Stream was {1}", Time.time, stream.CanWrite);
    }
    public int LoadGame()
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
            if (saveContainer.playerData.CanLoad)
            {
                Debug.Log(saveContainer);
                if (SpawnStuff == true)
                {
                    LoadEnemies(saveContainer);
                    //LoadWeapons(saveContainer);
                    LoadItems(saveContainer);
                    LoadGlobalStats(saveContainer);
                    LoadRoundStats(saveContainer);
                    LoadOldPlayerData(saveContainer);
                    LoadEnvironment(saveContainer);
                    LoadRooms(saveContainer);
                    //Debug.Log("save system 1");
                    LoadPlayer(saveContainer);
                    //Debug.Log("save system 2");

                }
                //Debug.Log("save system 3");
                stream.Close();
                //Debug.Log("save system 4");
                //Debug.LogFormat("Loaded game at {0}. Stream was {1}", Time.time, stream.CanRead);
                return 0;

            }

            else
            {
                Debug.Log("Could not load. Player was dead");
                stream.Close();
                //Debug.LogFormat("Loaded game at {0}. Stream was {1}", Time.time, stream.CanRead);
                return 1;
            }
            

            //return null;
            //return data;
        }
        else
        {
            Debug.Log("NoData");
            return 2;
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
                enemy.transform.parent = LoadedEnemiesHolder.transform;
            }
        }
        EvilPlayer.GetComponent<EvilPlayerLoader>().LoadEvilPlayer();
    }

    public void LoadItems(SaveContainer LoadedSaveContainer)
    {
        foreach (ItemData loadedItem in LoadedSaveContainer.levelData.itemData)
        {
            GameObject ItemPrefab = Dictionary.GetItemObjects(loadedItem.id);
            if (ItemPrefab != null)
            {
                GameObject item = Instantiate(ItemPrefab, loadedItem.position, Quaternion.identity);
                item.GetComponentInChildren<BaseItem>().ModId = loadedItem.ModId;
                item.transform.parent = LoadedItemsHolder.transform;
            }
        }
    }

    /*
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

    */

    public void LoadEnvironment(SaveContainer LoadedSaveContainer)
    {
        foreach (EnviroData loadedEnvironment in LoadedSaveContainer.levelData.enviromentData)
        {
            GameObject EnviroPrefab = Dictionary.GetEnviroObjects(loadedEnvironment.id);
            if (EnviroPrefab != null)
            {
                GameObject enviro = Instantiate(EnviroPrefab, loadedEnvironment.position, Quaternion.identity);
                enviro.transform.parent = LoadedEnvirosHolder.transform;
            }
        }
    }

 /*   public void LoadRooms(SaveContainer LoadedSaveContainer)
    {
        foreach (RoomData RoomRelation in LoadedSaveContainer.levelData.roomData)
        {
            Debug.Log(levelGen.rooms.Length);

            if (RoomRelation.roomIndex < levelGen.rooms.Length)
            {
                GameObject RoomPrefab = levelGen.rooms[RoomRelation.roomIndex];
                Instantiate(RoomPrefab, new Vector2(levelGen.StartingPosition.x + (RoomRelation.x-1) * levelGen.moveAmountx, levelGen.StartingPosition.y + (RoomRelation.y-1) * levelGen.moveAmounty), Quaternion.identity);
            }
        }
        EventController.instance.levelEvents.CallOnChunkGenerated();
    }

*/
    public void LoadRooms(SaveContainer LoadedSaveContainer)
    {
        foreach (RoomData loadedRoom in LoadedSaveContainer.levelData.roomData)
        {
            GameObject RoomPrefab = Dictionary.GetRoomObjects(loadedRoom.id);
            if (RoomPrefab != null)
            {
                GameObject room = Instantiate(RoomPrefab, loadedRoom.position, Quaternion.identity);
                room.transform.parent = LoadedRoomsHolder.transform;
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
        if (LoadedSaveContainer.playerData.currentweaponID < Dictionary.ItemObjects.Length)
        {
            GameObject CurrentWeapon = Dictionary.GetItemObjects(LoadedSaveContainer.playerData.currentweaponID);
            if (CurrentWeapon != null)
            {
                GameObject Weapon = Instantiate(CurrentWeapon, new Vector2(0, 0), Quaternion.identity);
                BaseWeapon weap = Weapon.GetComponentInChildren<BaseWeapon>();
                if (weap != null)
                {
                    weap.GetUITexts();
                    weap.ModId = LoadedSaveContainer.playerData.currentweaponModID;
                    weap.Start();
                    player.GetComponent<PlayerCombat>()?.ChangeWeapon(weap);
                    EventController.instance.itemEvents.CallOnItemDied(weap);
                }
                else
                {
                    Debug.Log("weap was null");
                }
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
        GameController.instance.DataStorage.PlayerInfo.cocoa = LoadedSaveContainer.playerData.cocoa;
        GameController.instance.DataStorage.PlayerInfo.blood = LoadedSaveContainer.playerData.blood;
        GameController.instance.DataStorage.PlayerInfo.currenthealth = LoadedSaveContainer.playerData.currenthealth;
        player.transform.position = LoadedSaveContainer.playerData.PlayerPosition;
    }

    public void LoadGlobalStats(SaveContainer LoadedSaveContainer)
    {
        GlobalStatistics.instance.enemiesKilled = LoadedSaveContainer.globalStatistics.enemiesKilled;
        GlobalStatistics.instance.timePassed = LoadedSaveContainer.globalStatistics.timePassed;
        GlobalStatistics.instance.bleedDamageDealt = LoadedSaveContainer.globalStatistics.bleedDamageDealt;
        GlobalStatistics.instance.doubleKills = LoadedSaveContainer.globalStatistics.doubleKills;
        GlobalStatistics.instance.fireDamageDealt = LoadedSaveContainer.globalStatistics.fireDamageDealt;
        GlobalStatistics.instance.playerDeaths = LoadedSaveContainer.globalStatistics.playerDeaths;
        GlobalStatistics.instance.poisonDamageDealt = LoadedSaveContainer.globalStatistics.poisonDamageDealt;


    
        //GlobalStatistics.instance.enemiesKilled = LoadedSaveContainer.globalStatsData.enemiesKilled;
        //GlobalStatistics.instance.timePassed = LoadedSaveContainer.globalStatsData.timePassed;

    }

    public void LoadRoundStats(SaveContainer LoadedSaveContainer)
    {
        RoundStatistics.instance.enemiesKilled = LoadedSaveContainer.roundStatistics.enemiesKilled;
        RoundStatistics.instance.damageTaken = LoadedSaveContainer.roundStatistics.damageTaken;
    }

    public void LoadOldPlayerData(SaveContainer LoadedSaveContainer)
    {
        if (LoadedSaveContainer.oldPlayerData != null)
        {
            saveContainer.oldPlayerData = LoadedSaveContainer.oldPlayerData;
            GameController.instance.DataStorage.EvilPlayerInfo.currentweaponID = LoadedSaveContainer.oldPlayerData.currentweaponID;
            GameController.instance.DataStorage.EvilPlayerInfo.currentweaponModID = LoadedSaveContainer.oldPlayerData.currentweaponModID;
            GameController.instance.DataStorage.EvilPlayerInfo.ItemIDs = LoadedSaveContainer.oldPlayerData.ItemIDs;
            GameController.instance.DataStorage.EvilPlayerInfo.level = LoadedSaveContainer.oldPlayerData.level;
            GameController.instance.DataStorage.EvilPlayerInfo.IsAlive = false;
            //EvilPlayer.GetComponent<EvilPlayerLoader>().LoadEvilPlayer();
            //Debug.LogFormat("Maxhealth value in oldPlayerData was {0}", LoadedSaveContainer.oldPlayerData.maxhealth);

        }
    }
    /*
    public void LoadEvilPlayer()
    {
        if (saveContainer.oldPlayerData.level == GameController.instance.DataStorage.PlayerInfo.level)
        {
            GameObject weap = Instantiate(Dictionary.GetItemObjects(GameController.instance.DataStorage.EvilPlayerInfo.currentweaponID),transform.position, Quaternion.identity);
            BaseWeapon weapScript = weap.GetComponent<BaseWeapon>();
            weapScript.ModId = GameController.instance.DataStorage.EvilPlayerInfo.currentweaponModID;
            EvilPlayer.GetComponent<EvilPlayerCombat>().ChangeWeapon(weapScript);

            foreach (int id in GameController.instance.DataStorage.EvilPlayerInfo.ItemIDs)
            {
                GameObject item = Instantiate(Dictionary.GetItemObjects(id), transform.position, Quaternion.identity);
                item.GetComponent<BaseItem>().EvilPickupItem();
            }
            EvilPlayer.GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    */
    public void LoadItemsData(SaveContainer LoadedSaveContainer)
    {
        itemDataController.unlockedItems = LoadedSaveContainer.itemsData.unlockedItems;
    }

    public void SaveItemsData()
    {
        saveContainer.itemsData.unlockedItems = itemDataController.unlockedItems;
    }

    [ContextMenu("Test")]
    public void FullySaveGame()
    {
        saveContainer.levelData.SaveItem(itemTracker.items);
        //saveContainer.levelData.SaveWeapon(weaponTracker.weapons);
        saveContainer.levelData.SaveEnemies(enemyTracker.enemies);
        saveContainer.levelData.SaveEnviroment(enviromentTracker.enviros);
        saveContainer.levelData.SaveRooms(roomTracker.rooms);
        saveContainer.playerData = new PlayerDataScript(GameController.instance.DataStorage.PlayerInfo);
        //Debug.LogFormat("Test 1:{0}", saveContainer.statisticsData.ToString());
        //Debug.LogFormat("Test 2:{0}", saveContainer.statisticsData.globalData.ToString());
        saveContainer.globalStatistics = new GlobalStatisticsDataScript(GlobalStatistics.instance);
        saveContainer.roundStatistics = new RoundStatisticsDataScript(RoundStatistics.instance);
        //saveContainer.statisticsData.roundData.SaveStatistics();
        SaveItemsData();

        SaveGame();
    }

    public void SaveOldPlayerData()
    {
        saveContainer.oldPlayerData = new PlayerDataScript(GameController.instance.DataStorage.PlayerInfo);
    }

    public void LoadPersistentData()
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
                LoadOldPlayerData(saveContainer);
                LoadGlobalStats(saveContainer);
                //jeszcze ładowanie odblokowanych itemków jak będzie
                LoadItemsData(saveContainer);

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

    private void OnApplicationQuit()
    {
        if (!MainMenu.activeSelf)
        {
            FullySaveGame();
            Debug.Log("Shutdown");
        }

    }
}
