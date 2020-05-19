﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    public Sprite mysprite1;
    private bool Rozlane=false;
    [SerializeField] private int amount;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player" && Rozlane!=true)
        {
            GameController.instance.DataStorage.PlayerInfo.blood += amount;
            EventController.instance.playerEvents.CallOnBloodPickup(amount);
            Destroy (gameObject);
        }
        else if (col.gameObject.layer ==8)
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite1;
            this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            FindObjectOfType<AudioManager>().Play("BloodPlum");
            Rozlane = true;
        }
        
    }

}