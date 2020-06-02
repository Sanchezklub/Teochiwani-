using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerWeapon : MonoBehaviour
{
    public void CheckPlayerWeaponFunction()
    {
        PlayerCombat Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        if (GameController.instance.DataStorage.PlayerInfo.currentweaponID >= SaveSystem.Instance.Dictionary.WeaponObjects.Length)
        {
            BaseWeapon weap = Player.currentWeapon;
            if (weap != null)
            {
                weap.DropWeapon();
                Destroy(weap.gameObject);
            }
        }
    }
}
