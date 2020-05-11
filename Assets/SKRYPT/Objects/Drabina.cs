using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drabina : MonoBehaviour
{
    [SerializeField] private float speed = 500;
    private float speed2 = 1;
    private bool LadderMode;
    [SerializeField] private Rigidbody2D Rb2D;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LadderMode = true;
            Rb2D.gravityScale = 0;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LadderMode = false;
            Rb2D.gravityScale = 2;
        }
    }

    private void Update()
    {
        float PlayerInput = Input.GetAxisRaw("Vertical");
        if(LadderMode == true)
        {
            switch (PlayerInput)
            {
                case -1:
                    Rb2D.isKinematic = false;
                    Rb2D.velocity = new Vector2(Rb2D.velocity.x, -speed);
                    break;
                case 1:
                    Rb2D.isKinematic = false;
                    Rb2D.velocity = new Vector2(Rb2D.velocity.x, speed);
                    break;
                case 0:
                    Rb2D.velocity = new Vector2(Rb2D.velocity.x,0);
                    break;
            }
        }
        
    }
}








