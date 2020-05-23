using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataScript
{
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
    public List<int> ItemIDs;

    public Vector3 testVector;


    public PlayerDataScript(PlayerInformation PlayerInfo)
    {
        maxhealth = PlayerInfo.maxhealth;
        currenthealth = PlayerInfo.currenthealth;
        cocoa = PlayerInfo.cocoa;
        blood = PlayerInfo.blood;
        damage = PlayerInfo.damage;
        speed = PlayerInfo.speed;
        currentweaponID = PlayerInfo.currentweaponID;
        ItemIDs = PlayerInfo.ItemIDs;
        PlayerPosition = PlayerInfo.playerPosition;
        //position_x = PlayerInfo.playerPosition.x;
        //position_y = PlayerInfo.playerPosition.y;
        //testVector = new Vector3(12f, 23, 2);
    }

}