using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKarma : MonoBehaviour
{
    
    public Slider karmabar;
    // Start is called before the first frame update
    void Start()
    {
        karmabar.value = 25;
    }

    // Update is called once per frame
    void Update()
    {
        karmabar.value = GameController.instance.DataStorage.PlayerInfo.karma;
    }
}
