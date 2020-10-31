using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class Kupiec : MonoBehaviour
{
    public Animator anim;
    public Sprite krew;
    public Sprite kakao;
    public bool PlayerInRange;
    public GameObject Price;
    public GameObject TypeOfPrice;
    public GameObject stragan;
    public GameObject[] bronieDoSpawnu;
    public GameObject weaponholder;
    int playerKakao;
    int playerBlood;
    int itemValueKakao;
    int itemValueBlood;  
    bool CenaWKakao;
    bool Sprzedane=false;
    int rand;
    public GameObject itemframe;
    public AudioSource audioData;
    public void Start()
    {
        audioData = GetComponent<AudioSource>();
        
    
       // Instantiate(stragan, new Vector3(transform.position.x+7,transform.position.y+2,transform.position.z), Quaternion.identity );
        GameObject ObjectStragan = Instantiate(stragan, new Vector3(transform.position.x-12,transform.position.y+7,transform.position.z), Quaternion.identity );
        ObjectStragan.transform.parent = this.transform;


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
            anim.SetTrigger("GraczWszedl");
            AudioManager.instance.Play("KupiecPierwszePoznanie");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerInRange = false;
        
        if (Sprzedane == false)
        {
        anim.SetTrigger("KupiecZły");
        AudioManager.instance.Play("KupiecWkurw");
        }
        }
    }
    private void idlesound()
    {
         AudioManager.instance.Play("KupiecIdle");
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
                GameController.instance.DataStorage.PlayerInfo.cocoa -= itemValueKakao;
                Debug.Log("Attempted to CallOnCocoaLost from Kupiec 1");
                EventController.instance.playerEvents.CallOnCocoaLost(itemValueKakao);
                Debug.Log("Attempted to CallOnCocoaLost from Kupiec 2");
                Instantiate(bronieDoSpawnu[rand], transform.position, Quaternion.identity);
                Sprzedane=true;
                anim.SetTrigger("KupiecDobry");
                AudioManager.instance.Play("Kupiec_Dobry");
                itemframe.GetComponent<SpriteRenderer>().sprite =null;
            }
            else if (CenaWKakao==false&& playerBlood>=itemValueBlood)
            {
                GameController.instance.DataStorage.PlayerInfo.blood -= itemValueBlood;
                Debug.Log("Attempted to CallOnBloodLost from Kupiec 1");

                EventController.instance.playerEvents.CallOnBloodLost(itemValueBlood);
                Debug.Log("Attempted to CallOnBloodLost from Kupiec 2");

                Instantiate(bronieDoSpawnu[rand], transform.position, Quaternion.identity);
               Sprzedane=true;
               anim.SetTrigger("KupiecDobry");
               AudioManager.instance.Play("Kupiec_Dobry");
               itemframe.GetComponent<SpriteRenderer>().sprite =null;
            }
        }
    }
}
