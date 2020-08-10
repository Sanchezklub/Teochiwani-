using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class potion : MonoBehaviour
{
    public Sprite[] potionImg;
    public int addHp;
    Image potionImage;
    

    void Start()
    {
        potionImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && GameController.instance.DataStorage.PlayerInfo.potionLoads > 0)
        {
            GameController.instance.DataStorage.PlayerInfo.currenthealth += addHp;
            GameController.instance.DataStorage.PlayerInfo.potionLoads -= 1;
        }
        
        switch (GameController.instance.DataStorage.PlayerInfo.potionLoads)
        {
            case 0:
            {
                potionImage.sprite = potionImg[0];
                break;
            }
             case 1:
            {
                potionImage.sprite = potionImg[1];
                break;
            } case 2:
            {
                potionImage.sprite = potionImg[2];
                break;
            } case 3:
            {
                potionImage.sprite = potionImg[3];
                break;
            }
        }
    }
}
