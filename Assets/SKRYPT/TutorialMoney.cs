using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMoney : MonoBehaviour
{
    public int kakao;
    public int blood;
    bool raz=false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !raz )
        {
            raz=true;
            GameController.instance.DataStorage.PlayerInfo.cocoa = kakao;
            GameController.instance.DataStorage.PlayerInfo.blood = blood;
        }
    }

    
}
