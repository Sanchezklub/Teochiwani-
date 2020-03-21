﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform portalik;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Player.transform.position = new Vector2(portalik.position.x, portalik.position.y);
    }
}
