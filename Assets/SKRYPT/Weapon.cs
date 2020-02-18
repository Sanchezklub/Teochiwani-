using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour 
{

    public Transform firePoint;
	public GameObject bulletPrefab;
    public float attackrate = 2f;
    float nextAttackTime=0f;

	
	// Update is called once per frame
	void Update () {
		
        if(Time.time>=nextAttackTime)
        {      
            if (Input.GetButtonDown("Fire2"))
		    {
			Shoot();
             nextAttackTime = Time.time +1f / attackrate;
		    }
        }
	}

	void Shoot ()
	{
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
