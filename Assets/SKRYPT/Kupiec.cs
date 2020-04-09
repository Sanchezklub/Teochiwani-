using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kupiec : MonoBehaviour
{
    
    private bool PlayerInRange;
    public GameObject stragan;
    public BaseWeapon[] bronie;
    int playerKakao;
    int playerBlood;
    int itemValueKakao;
    int itemValueBlood;  
    bool CenaWKakao;
    int rand;
    public void Start()
    {
     
    playerBlood = GameController.instance.DataStorage.PlayerInfo.blood;
    playerKakao = GameController.instance.DataStorage.PlayerInfo.cocoa;
    Instantiate(stragan, new Vector3(transform.position.x+10,transform.position.y,transform.position.z), Quaternion.identity );
    Instantiate(stragan, new Vector3(transform.position.x-10,transform.position.y,transform.position.z), Quaternion.identity );


    rand = Random.Range(0, bronie.Length);
    int rand2 = Random.Range(0, 2);

        if ( rand2 == 1)
        {
            CenaWKakao=true;   
            itemValueKakao=bronie[rand].CocaoPrice; 
        }
        else 
        {
            CenaWKakao=false;
            itemValueBlood=bronie[rand].BloodPrice; 
        }

    Instantiate(bronie[rand], transform.position, Quaternion.identity );
    Collider2D Coll = bronie[rand].GetComponent<Collider2D>();
    Coll.enabled = true;
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
        if(Input.GetKeyDown("e")  && PlayerInRange == true)
        {
            if ( CenaWKakao==true && playerKakao>=itemValueKakao)
            {
                GameController.instance.DataStorage.PlayerInfo.cocoa-= itemValueKakao;
                Coll.enabled = false;
            }
            else if (CenaWKakao==false&& playerBlood>=itemValueBlood)
            {
                GameController.instance.DataStorage.PlayerInfo.blood -= itemValueBlood;
                Coll.enabled = false;
            }
        }
    }
}
