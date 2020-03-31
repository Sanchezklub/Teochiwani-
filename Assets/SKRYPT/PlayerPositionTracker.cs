using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionTracker : MonoBehaviour
{
    Transform PlayerTransform;

    private void Start()
    {
        PlayerTransform = GetComponent<Transform>();
    }
    void Update()
    {
        GameController.instance.DataStorage.PlayerInfo.playerPosition = PlayerTransform.position;
        //PlayerTransform.Translate(GameController.instance.DataStorage.PlayerInfo.playerPosition);
    }
}
