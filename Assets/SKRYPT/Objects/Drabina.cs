using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drabina : MonoBehaviour
{
    /*

    [SerializeField] private float speed = 500;
    private float speed2 = 1;
    private bool LadderMode = false;
    private bool Player_ladderMode;
    private bool WasOnPreviousLadder = false;
    [SerializeField] private Rigidbody2D Rb2D;
    private CharacterController2D playerController;
    private int TriggerEnterCount = 0;

    private void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerController = other.GetComponent<CharacterController2D>();
            //playerController.ladderMode = true;
            Rb2D = other.attachedRigidbody;
            LadderMode = true;
            TriggerEnterCount += 1;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LadderMode = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //playerController = other.GetComponent<CharacterController2D>();
            Player_ladderMode = false;
            playerController.ladderMode = false;
            LadderMode = false;
            Rb2D.gravityScale = 2;
            TriggerEnterCount -= 1;
        }
    }

    private void Update()
    {
        if (LadderMode && Input.GetKeyDown(KeyCode.E))
        {
            if (Player_ladderMode == false)
            {
                Player_ladderMode = true;
                playerController.ladderMode = true;
                Rb2D.transform.position = new Vector2(transform.position.x, Rb2D.transform.position.y);
                Rb2D.gravityScale = 0;
            }
            else
            {
                Player_ladderMode = false;
                playerController.ladderMode = false;
                Rb2D.gravityScale = 2;
            }
        }


        if (Player_ladderMode == true)
        {
            float PlayerInput = Input.GetAxisRaw("Vertical");
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

    */
}








