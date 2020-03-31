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
    public float[] position;


    public PlayerDataScript (PlayerInformation PlayerInfo)
    {
            maxhealth = PlayerInfo.maxhealth;
            currenthealth = PlayerInfo.currenthealth;
            cocoa = PlayerInfo.cocoa;
            blood = PlayerInfo.blood;
            damage = PlayerInfo.damage;
            speed = PlayerInfo.speed;
            //position[0] = PlayerInfo.playerPosition.x;
            //position[1] = PlayerInfo.playerPosition.y;
    }

}
