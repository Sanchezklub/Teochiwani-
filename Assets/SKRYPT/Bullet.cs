using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 20;
	public Rigidbody2D rb2d;
// jak bedziemy chceili dodac efekt po strzale	public GameObject impactEffect;

	void Start () 
    {
		rb2d.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		hitInfo.GetComponent<Health>()?.TakeDamage(damage);

	// tak jak wyzej 	Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	
}