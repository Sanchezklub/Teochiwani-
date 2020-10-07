using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 20;
	public Rigidbody2D rb2d;
	public float RotationSpeed;

	private float targ_x;
	private float targ_y;

    public ParticleSystem HitParticle;

    public Vector3 target;
	Vector2 moveDirection;
	// jak bedziemy chceili dodac efekt po strzale	public GameObject impactEffect;

	void Start () 
    {

		rb2d = GetComponent<Rigidbody2D>();
		//target = GameObject.Find("Player");
		moveDirection = (target - transform.position).normalized * speed;
		rb2d.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Vector3 objectPos = transform.position;
		targ_x = target.x - objectPos.x;
		targ_y = target.y - objectPos.y;

		float angle = Mathf.Atan2(targ_y, targ_x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
		
		//rb2d.velocity = transform.right * speed;
		//rb2d.MoveRotation(-90 - Mathf.Atan2(rb2d.velocity.x, rb2d.velocity.y) * 180);
	}
	private void Update()
	{
		rb2d.MoveRotation(Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x)*(180/Mathf.PI));
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		hitInfo.GetComponent<Health>()?.TakeDamage(damage);
        HitParticle.Play();
	// tak jak wyzej 	Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
	
}