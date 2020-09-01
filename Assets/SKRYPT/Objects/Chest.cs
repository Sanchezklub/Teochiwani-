using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chest : MonoBehaviour
{
    public Sprite mysprite1;
    [SerializeField] private bool IsOpen = false;
    [SerializeField] private bool WeaponsOnly = false;
    private bool PlayerInRange;
    //public GameObject[] objects;
    public GameObject Particle;
    public BoxCollider2D bc;
    private int rand;
    public GameObject UIHELP;
    public GameObject Minimap;
    
    
    //private void Start()
    //{
        //objects = SaveSystem.Instance.saveContainer.itemsData.unlockedItems;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerInRange = true;
            if(IsOpen==false)
            {
                UIHELP.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerInRange = false;
            if(IsOpen==false)
            {
            UIHELP.SetActive(false);
            }
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
        Minimap.SetActive(false);
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
        rand = Random.Range(0, SaveSystem.Instance.saveContainer.itemsData.unlockedItems.Count);
        Debug.Log(SaveSystem.Instance.saveContainer.itemsData.unlockedItems[rand]);
        if (WeaponsOnly)
        {
            while(SaveSystem.Instance.saveContainer.itemsData.unlockedItems[rand] < 100)
            {
                rand = Random.Range(0, SaveSystem.Instance.saveContainer.itemsData.unlockedItems.Count);
                Debug.Log(SaveSystem.Instance.saveContainer.itemsData.unlockedItems[rand]);
            }
        }
        GameObject loot = Instantiate(SaveSystem.Instance.Dictionary.ItemObjects[SaveSystem.Instance.saveContainer.itemsData.unlockedItems[rand]], new Vector2(transform.position.x, transform.position.y + 3), Quaternion.identity );
        loot.transform.parent = this.transform.parent;
    }
}