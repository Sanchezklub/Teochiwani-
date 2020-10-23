using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoActions : MonoBehaviour
{
    private float previousMaxhealth;
    private float previousCurrenthealth;
    private void Start()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage += GameController.instance.DataStorage.PlayerInfo.CallOnGetHurtAction;
        EventController.instance.playerEvents.OnPlayerDie += GameController.instance.DataStorage.PlayerInfo.CallOnDieAction;

        EventController.instance.evilPlayerEvents.OnEvilPlayerReceiveDamage += GameController.instance.DataStorage.EvilPlayerInfo.CallOnGetHurtAction;
        EventController.instance.evilPlayerEvents.OnEvilPlayerDie += GameController.instance.DataStorage.EvilPlayerInfo.CallOnDieAction;
    }

    /*
    private void Update()
    {
        CheckMaxhealth();
        CheckCurrentHealth();
    }

    void CheckMaxhealth()
    {
        if (GameController.instance.DataStorage.PlayerInfo.maxhealth == previousMaxhealth)
        {
            return;
        }
        previousMaxhealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        EventController.instance.playerEvents.CallOnHealthValueChange();
    }
    void CheckCurrentHealth()
    {
        if (GameController.instance.DataStorage.PlayerInfo.currenthealth == previousCurrenthealth)
        {
            return;
        }
        previousCurrenthealth = GameController.instance.DataStorage.PlayerInfo.currenthealth;
        EventController.instance.playerEvents.CallOnHealthValueChange();
    }
    */
}
