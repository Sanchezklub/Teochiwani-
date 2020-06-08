﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strzala : MonoBehaviour
{
    Rigidbody2D rb;
    PolygonCollider2D pc;
    bool hasHit;
    public int damage = 20;
    public int Range =2;
    public LayerMask Player;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        pc=GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hasHit==false)
        {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x)* Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward );
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit=true;
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        pc.isTrigger=true;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, Range, Player);
        foreach (Collider2D enemy in hitEnemies)         
        {
        enemy.GetComponent<Health>()?.TakeDamage(damage);
        }
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
	{   if(hasHit==false)
		{
            hitInfo.GetComponent<Health>()?.TakeDamage(damage);
            hasHit=true;
        }
	}
}
