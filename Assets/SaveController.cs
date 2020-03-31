using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public PlayerDataScript LoadedData;

    public void SavePlayerInfo()
    {
        SaveSystem.SavePlayer(GameController.instance.DataStorage.PlayerInfo);
    }

    public void LoadPlayerInfo()
    {
        LoadedData = SaveSystem.LoadPlayer();
        GameController.instance.DataStorage.PlayerInfo.maxhealth = LoadedData.maxhealth;
        GameController.instance.DataStorage.PlayerInfo.currenthealth = LoadedData.currenthealth;
        GameController.instance.DataStorage.PlayerInfo.cocoa = LoadedData.cocoa;
        GameController.instance.DataStorage.PlayerInfo.blood = LoadedData.blood;
        GameController.instance.DataStorage.PlayerInfo.damage = LoadedData.damage;
        GameController.instance.DataStorage.PlayerInfo.speed = LoadedData.speed;
        //GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector3(LoadedData.position[0], LoadedData.position[1]));
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


}
