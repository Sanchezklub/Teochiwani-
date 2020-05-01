using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dzik : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody2D;
    public float damage;
    public float speed;
    public bool FacingRight;

    // Start is called before the first frame update
    void Start()
    {
        StartCharge();
    }

    // Update is called once per frame
    void Update()
    {
        KeepCharging();
    }




    public void StartCharge()
    {
        float PositionDifference = transform.position.x - GameController.instance.DataStorage.PlayerInfo.playerPosition.x; 
        if (PositionDifference >= 0)
        {
            if (FacingRight)
            {
                Flip();
            }
            FacingRight = true;
        }
        else if (PositionDifference <= 0)
        {
            if (!FacingRight)
            {
                Flip();
            }
            FacingRight = false;
        }
    }

    private void OnCollisionEnter2D(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
    }

    void Flip()
    {
        transform.Rotate(new Vector2(0f, 180f));
        FacingRight = !FacingRight;
    }


    void KeepCharging()
    {
        if (FacingRight == false)
        {
            enemyRigidBody2D.velocity = new Vector2(1 * speed, enemyRigidBody2D.velocity.y);
        }
        else
        {
            enemyRigidBody2D.velocity = new Vector2(-1 * speed, enemyRigidBody2D.velocity.y);
        }
    }
}
