using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKarma : MonoBehaviour
{
    float karma;
    public Slider karmabar;
    // Start is called before the first frame update
    void Start()
    {
        karma =  GameController.instance.DataStorage.PlayerInfo.karma;
    }

    // Update is called once per frame
    void Update()
    {
        karmabar.value = karma;
    }
}
