using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Stragan : MonoBehaviour
{
    public Sprite krew;
    public Sprite kakao;
    public bool PlayerInRange;
    public GameObject Price;
    public GameObject TypeOfPrice;
    public GameObject[] bronieDoSpawnu;
    int playerKakao;
    int playerBlood;
    int itemValueKakao;
    int itemValueBlood;  
    bool CenaWKakao;
    bool Sprzedane=false;
    int rand;
    public GameObject itemframe;
    public void Start()
    {

        rand = Random.Range(0, bronieDoSpawnu.Length); // losuje broń
        int rand2 = Random.Range(0, 2);  // losuje czy cena bedzie w kakao czy w krwi 

        if ( rand2 == 1)
        {
            CenaWKakao=true;   
            itemValueKakao=bronieDoSpawnu[rand].GetComponentInChildren<BaseItem>().CocaoPrice;
            TypeOfPrice.GetComponent<SpriteRenderer>().sprite = kakao;
            Price.GetComponent<TextMeshPro>().text = itemValueKakao.ToString();
        }
        else 
        {
            CenaWKakao=false;
            itemValueBlood=bronieDoSpawnu[rand].GetComponentInChildren<BaseItem>().BloodPrice;
            TypeOfPrice.GetComponent<SpriteRenderer>().sprite = krew;
            Price.GetComponent<TextMeshPro>().text = itemValueBlood.ToString();
        }
        itemframe.GetComponent<SpriteRenderer>().sprite = bronieDoSpawnu[rand].GetComponentInChildren<SpriteRenderer>().sprite;
    
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
        Collider2D Coll = bronieDoSpawnu[rand].GetComponent<Collider2D>();
        if(Input.GetKeyDown("e")  && PlayerInRange == true && Sprzedane == false)
        {
        playerBlood = GameController.instance.DataStorage.PlayerInfo.blood; // Pobranie ilosci kasy ktora ma gracz
        playerKakao = GameController.instance.DataStorage.PlayerInfo.cocoa;
            if ( CenaWKakao==true && playerKakao>=itemValueKakao)
            {
                GameController.instance.DataStorage.PlayerInfo.cocoa-= itemValueKakao;
               Instantiate(bronieDoSpawnu[rand], transform.position, Quaternion.identity);
                Sprzedane=true;
                itemframe.GetComponent<SpriteRenderer>().sprite =null;
            }
            else if (CenaWKakao==false&& playerBlood>=itemValueBlood)
            {
                GameController.instance.DataStorage.PlayerInfo.blood -= itemValueBlood;
               Instantiate(bronieDoSpawnu[rand], transform.position, Quaternion.identity);
               Sprzedane=true;
               itemframe.GetComponent<SpriteRenderer>().sprite =null;
            }
        }
    }
}
