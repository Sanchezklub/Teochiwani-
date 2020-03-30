using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int level;
    public int health;
    public int jumpforce;
    public int BaseAttackDamage;
    public int CurrentWeapon;
    public float[] Position ;

    public PlayerData(Player Player )
    {
        level = Player.level ;
    }
}
