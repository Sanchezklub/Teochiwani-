﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoActions : MonoBehaviour
{
    private void Start()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage += GameController.instance.DataStorage.PlayerInfo.CallOnGetHurtAction;
        EventController.instance.playerEvents.OnPlayerDie += GameController.instance.DataStorage.PlayerInfo.CallOnDieAction;
    }
}
