﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject Player;
    public GameObject Portalw;
    public void Start()
    {
        Portalw = GameObject.Find("Portalw");
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.tag =="Player")
        {
            StartCoroutine (Teleport());
        }
    }
    IEnumerator Teleport()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        yield return new WaitForSeconds(1);
        //portalik=Portalw.transform;
       // Player.transform.position = new Vector2(portalik.position.x+1, portalik.position.y);
        if (Portalw == null)
        {
            Portalw = GameController.instance.Portal;
        }
        Player.transform.position = Portalw.transform.position;
    }
}
    

