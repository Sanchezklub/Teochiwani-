using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drabina : MonoBehaviour
{
    private float speed = 10;
    private float speed2 = 1;
    [SerializeField]private Rigidbody2D Rb2D;


    void OnTriggerStay2D(Collider2D other)
    {
        float PlayerInput = Input.GetAxisRaw("Vertical");
        switch (PlayerInput)
        {
            case -1:
                Rb2D.velocity = new Vector2(Rb2D.velocity.x, -speed);
                break;
            case 1:
                Rb2D.velocity = new Vector2(Rb2D.velocity.x, speed);
                break;
            case 0:
                Rb2D.velocity = new Vector2(Rb2D.velocity.x, 0);
                break;
        }


    }





}
