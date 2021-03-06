﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerLoader : MonoBehaviour
{
    [SerializeField] private EvilPlayerCombat combat;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private List<int> bannedItems;

    public void LoadEvilPlayer()
    {
        if (GameController.instance.DataStorage.EvilPlayerInfo.level == GameController.instance.DataStorage.PlayerInfo.level)
        {
            if (SaveSystem.Instance.Dictionary.GetItemObjects(GameController.instance.DataStorage.EvilPlayerInfo.currentweaponID) != null)
            {
                GameObject weap = Instantiate(SaveSystem.Instance.Dictionary.GetItemObjects(GameController.instance.DataStorage.EvilPlayerInfo.currentweaponID), transform.position, Quaternion.identity);
                BaseWeapon weapScript = weap.GetComponentInChildren<BaseWeapon>();
                if(weapScript != null)
                {
                    weapScript.ModId = GameController.instance.DataStorage.EvilPlayerInfo.currentweaponModID;
                    combat.ChangeWeapon(weapScript);
                }

            }

            foreach (int id in GameController.instance.DataStorage.EvilPlayerInfo.ItemIDs)
            {
                if (!bannedItems.Contains(id) && SaveSystem.Instance.Dictionary.GetItemObjects(id) != null)
                {
                    GameObject item = Instantiate(SaveSystem.Instance.Dictionary.GetItemObjects(id), transform.position, Quaternion.identity);
                    item.GetComponent<BaseItem>().EvilPickupItem();
                }
            }
            if (GameController.instance.DataStorage.EvilPlayerInfo.ItemIDs.Count != 0)
            {
                int rand = Random.Range(0, GameController.instance.DataStorage.EvilPlayerInfo.ItemIDs.Count);
                GetComponent<EvilPlayerHealth>().Drops[0] = SaveSystem.Instance.Dictionary.GetItemObjects(GameController.instance.DataStorage.EvilPlayerInfo.ItemIDs[rand]);
            }

            rb.simulated = true;
            transform.position = new Vector2(-301.5f, 67.6f);
        }
        else
        {
            this.transform.position = new Vector2(-3000, 0);
            rb.simulated = false;
        }
    }

    private void Start()
    {
        EventController.instance.levelEvents.OnLevelGeneratedBasic += LoadEvilPlayer;
        //EventController.instance.evilPlayerEvents.OnEvilPlayerReceiveDamage += GameController.instance.DataStorage.EvilPlayerInfo.GetHitAction;
        //EventController.instance.evilPlayerEvents.OnEvilPlayerDie += GameController.instance.DataStorage.EvilPlayerInfo.DieAction;
    }
    private void OnDestroy()
    {
        EventController.instance.levelEvents.OnLevelGeneratedBasic -= LoadEvilPlayer;
    }
}
