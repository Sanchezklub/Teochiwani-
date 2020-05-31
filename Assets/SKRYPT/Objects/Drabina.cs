using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drabina : MonoBehaviour
{
    [SerializeField] private float speed = 500;
    private float speed2 = 1;
    private bool LadderMode;
    [SerializeField] private Rigidbody2D Rb2D;
    private CharacterController2D playerController;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerController = other.GetComponent<CharacterController2D>();
            playerController.ladderMode = true;
            Rb2D = other.attachedRigidbody;
            LadderMode = true;
            Rb2D.gravityScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        playerController.ladderMode = true;
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerController = other.GetComponent<CharacterController2D>();
            playerController.ladderMode = false;
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








