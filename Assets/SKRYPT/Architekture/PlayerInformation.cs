using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Player/PlayerInfo", order = 0)]
public class PlayerInformation : ScriptableObject
{
    public float maxhealth;
    public float currenthealth;
    public float damage;
    public float speed;
    public float crouchspeed;
    public float jumpforce;
    //jeszcze coś z bronią, itp.

    public Vector3 playerPosition;
    public int weapon;
    public int cocoa;
    public int blood;
}