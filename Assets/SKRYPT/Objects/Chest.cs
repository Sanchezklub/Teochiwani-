using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite mysprite1;
    [SerializeField] private bool IsOpen = false;
    private bool PlayerInRange;
    //public GameObject[] objects;
    public GameObject Particle;
    public BoxCollider2D bc;


    //private void Start()
    //{
        //objects = SaveSystem.Instance.saveContainer.itemsData.unlockedItems;
    //}

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
        FindObjectOfType<AudioManager>().Play("ChestOpen");
        Debug.Log("Loot");
        IsOpen = true;
        this.GetComponent<SpriteRenderer>().sprite = mysprite1;
        if (Particle != null)
        {
            Instantiate(this.Particle, transform.position, Quaternion.identity);
        }
        Spawn();
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        bc.isTrigger=true;
        EnviroId Enviroid = GetComponent<EnviroId>();
        EventController.instance.enviromentEvents.CallOnEnviroDied(Enviroid);
        Enviroid.id = 3;
        EventController.instance.enviromentEvents.CallOnEnviroAppear(Enviroid);
        
    }
    private void Spawn()
    {
        int rand = Random.Range(0, SaveSystem.Instance.saveContainer.itemsData.unlockedItems.Count);
        GameObject loot = Instantiate(SaveSystem.Instance.Dictionary.ItemObjects[rand], new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity );
        loot.transform.parent = this.transform.parent;
    }
}