using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKarma : MonoBehaviour
{
    
    public SimpleSlider karmabar;
    // Start is called before the first frame update
    void Start()
    {
        karmabar.targetValue = 0.5f;
        EventController.instance.enemyEvents.OnEnemyDiedBasic += OnEnemyDiedBasic;
    }

    // Update is called once per frame
    void OnEnemyDiedBasic()
    {
        karmabar.targetValue = (GameController.instance.DataStorage.PlayerInfo.karma)/50;
    }
}
