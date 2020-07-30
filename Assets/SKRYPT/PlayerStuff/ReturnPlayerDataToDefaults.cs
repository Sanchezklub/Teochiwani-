﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnPlayerDataToDefaults : MonoBehaviour
{
    public float maxhealth;
    public float currenthealth;
    public float damage;
    public float speed;
    public float crouchspeed;
    public float jumpforce;
    public float karma;
    public float attackspeed;
    public int level;
    //jeszcze coś z bronią, itp.

    public Vector3 playerPosition;
    public int weapon;
    public int cocoa;
    public int blood;
    private GameObject Player;

    public void ManuallyResetPlayerData()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GameController.instance.DataStorage.PlayerInfo.maxhealth = maxhealth;
        GameController.instance.DataStorage.PlayerInfo.currenthealth = maxhealth;
        GameController.instance.DataStorage.PlayerInfo.damage = damage;
        GameController.instance.DataStorage.PlayerInfo.speed = speed;
        GameController.instance.DataStorage.PlayerInfo.crouchspeed = crouchspeed;
        GameController.instance.DataStorage.PlayerInfo.jumpforce = jumpforce;
        GameController.instance.DataStorage.PlayerInfo.attackspeed = attackspeed;
        if (Player != null)
        {
            Player.transform.position = new Vector2 (SaveSystem.Instance.levelGen.StartingPosition.x - SaveSystem.Instance.levelGen.moveAmountx, SaveSystem.Instance.levelGen.StartingPosition.y);
        }
        //Player.transform.position = Vector3.zero;
        GameController.instance.DataStorage.PlayerInfo.weapon = weapon;
        GameController.instance.DataStorage.PlayerInfo.cocoa = cocoa;
        GameController.instance.DataStorage.PlayerInfo.blood = blood;
        GameController.instance.DataStorage.PlayerInfo.karma = karma;
        GameController.instance.DataStorage.PlayerInfo.level = level;
        GameController.instance.DataStorage.PlayerInfo.currentweaponID = 9999;
        //GameController.instance.DataStorage.PlayerInfo.currentWeapon = null;
        GameController.instance.DataStorage.PlayerInfo.ItemIDs.Clear();
    }
}
