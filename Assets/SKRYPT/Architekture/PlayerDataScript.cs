﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataScript
{
    public float attackspeed;
    public float maxhealth;
    public float currenthealth;
    public int cocoa;
    public int blood;
    public float damage;
    public float speed;
    public Vector3 PlayerPosition;
    //public float position_x;
    //public float position_y;
    //public string currentweapon;
    public int currentweaponID;
    public int currentweaponModID;
    public List<int> ItemIDs;

    public float TimeInGame;
    public int potionLoads;
    public int level;
    public Vector3 testVector;

    public Vector2 portalPosition;

    public bool CanLoad;

    public PlayerDataScript(PlayerInformation PlayerInfo)
    {
        attackspeed = PlayerInfo.attackspeed;
        maxhealth = PlayerInfo.maxhealth;
        currenthealth = PlayerInfo.currenthealth;
        cocoa = PlayerInfo.cocoa;
        blood = PlayerInfo.blood;
        damage = PlayerInfo.damage;
        speed = PlayerInfo.speed;
        currentweaponID = PlayerInfo.currentweaponID;
        currentweaponModID = PlayerInfo.currentweaponModID;
        ItemIDs = PlayerInfo.ItemIDs;
        PlayerPosition = PlayerInfo.playerPosition;
        potionLoads = PlayerInfo.potionLoads;
        level = PlayerInfo.level;
        TimeInGame = GameController.instance.DataStorage.PlayerInfo.TimeInGame;
        //position_x = PlayerInfo.playerPosition.x;
        //position_y = PlayerInfo.playerPosition.y;
        //testVector = new Vector3(12f, 23, 2);
        CanLoad = (PlayerInfo.IsAlive && !PlayerInfo.IsInTutorial && !PlayerInfo.BeatenGame);
        portalPosition = PlayerInfo.portalPosition;
    }

}