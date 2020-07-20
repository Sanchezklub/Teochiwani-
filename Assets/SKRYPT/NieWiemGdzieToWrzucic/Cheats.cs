using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameController.instance.DataStorage.PlayerInfo.maxhealth += 100;
                GameController.instance.DataStorage.PlayerInfo.currenthealth += 100;
            }
        }        
    }
}
