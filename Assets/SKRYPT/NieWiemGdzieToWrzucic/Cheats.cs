using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{

    [SerializeField] private GameObject CheatAxe;
    [SerializeField] private GameObject Player;
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameController.instance.DataStorage.PlayerInfo.maxhealth += 100;
                EventController.instance.playerEvents.CallOnMaxhealthValueChange(100);
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
        }        
    }
}
