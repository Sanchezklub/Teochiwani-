using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 20f;
	public int damage = 20;
	public Rigidbody2D rb2d;
// jak bedziemy chceili dodac efekt po strzale	public GameObject impactEffect;

	void Start () 
    {
		rb2d.velocity = transform.right * speed;
		//rb2d.MoveRotation(-90 - Mathf.Atan2(rb2d.velocity.x, rb2d.velocity.y) * 180);
	}
	private void Update()
	{
		rb2d.MoveRotation(Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x)*180);
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		hitInfo.GetComponent<Health>()?.TakeDamage(damage);

	// tak jak wyzej 	Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
