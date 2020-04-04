using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static SaveController instance;

    public PlayerDataScript LoadedData;
    private GameObject PlayersOldWeapon;
    private GameObject LoadedWeapon;
    private GameObject player;
    private BaseWeapon LoadedWeaponScript;
    //public GameObject FloatingTextPrefab;
    public void SavePlayerInfo()
    {
        SaveSystem.SavePlayer(GameController.instance.DataStorage.PlayerInfo);
        Debug.Log("Game Saved");
    }

    public void LoadPlayerInfo()
    {
        LoadedData = SaveSystem.LoadPlayer();
        if (LoadedData != null)
        {
            GameController.instance.DataStorage.PlayerInfo.maxhealth = LoadedData.maxhealth;
            GameController.instance.DataStorage.PlayerInfo.currenthealth = LoadedData.currenthealth;
            GameController.instance.DataStorage.PlayerInfo.cocoa = LoadedData.cocoa;
            GameController.instance.DataStorage.PlayerInfo.blood = LoadedData.blood;
            GameController.instance.DataStorage.PlayerInfo.damage = LoadedData.damage;
            GameController.instance.DataStorage.PlayerInfo.speed = LoadedData.speed;
            //GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector3(LoadedData.position[0], LoadedData.position[1]));
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = new Vector3(LoadedData.position_x, LoadedData.position_y);
            PlayersOldWeapon = GameObject.Find(player.GetComponent<PlayerCombat>()?.currentWeapon?.name);
            LoadedWeapon = GameObject.Find(LoadedData?.currentweapon);
            Debug.Log(LoadedWeapon?.name);
            if (LoadedWeapon != PlayersOldWeapon)
            {
                Destroy(PlayersOldWeapon);
                LoadedWeapon.transform.position = new Vector3(LoadedData.position_x, LoadedData.position_y);
                LoadedWeaponScript = LoadedWeapon.GetComponent<BaseWeapon>();
                player.GetComponent<PlayerCombat>()?.ChangeWeapon(LoadedWeaponScript);
            }


        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SavePlayerInfo();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            LoadPlayerInfo();
        }
    }
    //LoadedWeapon.transform.Translate(new Vector3(LoadedData.position[0], LoadedData.position[1], 0));

    /*public void ShowFloatingText(string text)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = text;
    }
    */

}