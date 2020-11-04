using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{

    [SerializeField] private GameObject CheatAxe;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Rhino;
    [SerializeField] private GameObject Portal;
    [SerializeField] private GameObject[] Weapon;
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameController.instance.DataStorage.PlayerInfo.maxhealth += 100;
                EventController.instance.playerEvents.CallOnHealthValueChange();
                GameController.instance.DataStorage.PlayerInfo.currenthealth += 100;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                GameObject.Instantiate(CheatAxe, GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Player.transform.position = new Vector2(1900, 20);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Instantiate(Rhino, GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
                Instantiate(Portal, GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Player.GetComponent<Health>().TakeDamage(GameController.instance.DataStorage.PlayerInfo.currenthealth);
            }
        }   
        if (Input.GetKey(KeyCode.O))
        {
           if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                 GameObject.Instantiate(Weapon[0], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }    
             if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                 GameObject.Instantiate(Weapon[1], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }     
             if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                 GameObject.Instantiate(Weapon[2], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }  
             if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                 GameObject.Instantiate(Weapon[3], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }   
             if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                 GameObject.Instantiate(Weapon[4], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }   
             if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                 GameObject.Instantiate(Weapon[5], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }   
             if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                 GameObject.Instantiate(Weapon[6], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }   
             if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                 GameObject.Instantiate(Weapon[7], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }    
             if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                 GameObject.Instantiate(Weapon[8], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }   
             if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                 GameObject.Instantiate(Weapon[9], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }   
            if (Input.GetKeyDown(KeyCode.F1))
            {
                 GameObject.Instantiate(Weapon[10], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }  
            if (Input.GetKeyDown(KeyCode.F2))
            {
                 GameObject.Instantiate(Weapon[11], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }  
            if (Input.GetKeyDown(KeyCode.F3))
            {
                 GameObject.Instantiate(Weapon[12], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.identity);
            }  
        }
    }
}
