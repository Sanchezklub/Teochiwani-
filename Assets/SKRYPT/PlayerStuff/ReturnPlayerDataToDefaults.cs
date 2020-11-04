using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ReturnPlayerDataToDefaults : MonoBehaviour
{
    public PlayerInformation[] infos;
    public float maxhealth;
    public float currenthealth;
    public float damage;
    public float speed;
    public float crouchspeed;
    public float jumpforce;
    public float karma;
    public float attackspeed;
    public int level;
    public int potionLoads;
    //jeszcze coś z bronią, itp.

    public Vector3 playerPosition;
    public int weapon;
    public int cocoa;
    public int blood;
    public float TimeInGame;
    private GameObject Player;

    public void ManuallyResetPlayerData()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player != null)
        {
            Player.transform.position = new Vector2 (SaveSystem.Instance.levelGen.StartingPosition.x - SaveSystem.Instance.levelGen.moveAmountx, SaveSystem.Instance.levelGen.StartingPosition.y);
        }
        foreach (PlayerInformation info in infos)
        {
            info.maxhealth = maxhealth;
            info.currenthealth = maxhealth;
            info.damage = damage;
            info.speed = speed;
            info.crouchspeed = crouchspeed;
            info.jumpforce = jumpforce;
            info.attackspeed = attackspeed;
            info.potionLoads = potionLoads;
            //Player.transform.position = Vector3.zero;
            info.TimeInGame =  0 ;
            info.blood = blood;
            info.karma = karma;
            info.level = level;
            info.currentweaponID = 9999;
            info.ItemIDs.Clear();
            //GameController.instance.DataStorage.PlayerInfo.currentWeapon = null;
        }
            GameController.instance.DataStorage.PlayerInfo.IsAlive = true;
            GameController.instance.DataStorage.PlayerInfo.cocoa = cocoa;
            GameController.instance.DataStorage.PlayerInfo.weapon = weapon;

    }
}
