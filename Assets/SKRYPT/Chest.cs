using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite mysprite1;
    private bool IsOpen = false;
    private bool PlayerInRange;
    public GameObject[] objects;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerInRange = false;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown("e") && IsOpen == false && PlayerInRange == true)
        {
            Open();
        }
    }
    void Open()
    {
        Debug.Log("Loot");
        IsOpen = true;
        this.GetComponent<SpriteRenderer>().sprite = mysprite1;
        Spawn();
        
    }
    private void Spawn()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], transform.position, Quaternion.identity );
    }
}