using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "Player/PlayerInfo", order = 0)]
public class PlayerInformation : ScriptableObject
{
    public float maxhealth;
    public float currenthealth;
    public float damage;
    public float speed;
    public float crouchspeed;
    public float jumpforce;
    public float karma;
    public float attackspeed;
    //jeszcze coś z bronią, itp.

    public Vector3 playerPosition;
    public int weapon;
    public int cocoa;
    public int blood;
    public int potionLoads;

    public int level;
    //public string currentWeapon;
    public List<int> ItemIDs;
    public int currentweaponID;
    public int currentweaponModID;

    public bool IsAlive = true;

    public UnityAction<float, float> GetHitAction;

    public void CallOnGetHurtAction(float damage, float healthleft)
    {
        GetHitAction?.Invoke(damage, healthleft);
    }

    public UnityAction DieAction;

    public void CallOnDieAction()
    {
        DieAction?.Invoke();
    }
}