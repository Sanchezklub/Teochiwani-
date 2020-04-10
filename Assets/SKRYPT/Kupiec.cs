using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kupiec : MonoBehaviour
{
    // brakuje textu 
    public bool PlayerInRange;
    public GameObject stragan;
    public Sprite[] broniewyglad;
    public BaseWeapon[] bronie;
    public GameObject[] bronieDoSpawnu;
    int playerKakao;
    int playerBlood;
    int itemValueKakao;
    int itemValueBlood;  
    bool CenaWKakao;
    bool Sprzedane=false;
    int rand;
    public void Start()
    {
     
    
        Instantiate(stragan, new Vector3(transform.position.x+15,transform.position.y,transform.position.z), Quaternion.identity );
        Instantiate(stragan, new Vector3(transform.position.x-15,transform.position.y,transform.position.z), Quaternion.identity );


        rand = Random.Range(0, bronie.Length); // losuje broń
        int rand2 = Random.Range(0, 2);  // losuje czy cena bedzie w kakao czy w krwi 

        if ( rand2 == 1)
        {
            CenaWKakao=true;   
            itemValueKakao=bronie[rand].GetComponent<ItemValue>().CocaoValue;
        }
        else 
        {
            CenaWKakao=false;
            itemValueBlood=bronie[rand].GetComponent<ItemValue>().BloodValue;
        }
        Instantiate(broniewyglad[0], transform.position, Quaternion.identity);
        Debug.Log("Instantiated sprite");
    
    }
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
        Collider2D Coll = bronie[rand].GetComponent<Collider2D>();
        if(Input.GetKeyDown("e")  && PlayerInRange == true && Sprzedane == false)
        {
        playerBlood = GameController.instance.DataStorage.PlayerInfo.blood; // Pobranie ilosci kasy ktora ma gracz
        playerKakao = GameController.instance.DataStorage.PlayerInfo.cocoa;
            if ( CenaWKakao==true && playerKakao>=itemValueKakao)
            {
                GameController.instance.DataStorage.PlayerInfo.cocoa-= itemValueKakao;
               Instantiate(bronieDoSpawnu[rand], transform.position, Quaternion.identity);
                Sprzedane=true;
            }
            else if (CenaWKakao==false&& playerBlood>=itemValueBlood)
            {
                GameController.instance.DataStorage.PlayerInfo.blood -= itemValueBlood;
               Instantiate(bronieDoSpawnu[rand], transform.position, Quaternion.identity);
               Sprzedane=true;
            }
        }
    }
}
