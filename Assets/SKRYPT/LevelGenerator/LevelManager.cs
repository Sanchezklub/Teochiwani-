using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private LevelDeleter deleter;
    [SerializeField] private LevelGeneration levelGen;
    [SerializeField] private GameObject player;
    private void Start()
    {
        EventController.instance.enemyEvents.OnBossDiedBasic += OnBossDied;
    }

    void OnBossDied()
    {
        deleter.Delete();
        GameController.instance.DataStorage.PlayerInfo.level = 2;
        //tutaj dać rzeczy z karmą i obecnym poziomem żeby zdecydować jaką wartość przypisać GameController.instance.DataStorage.PlayerInfo.level
        levelGen.Create();
        player.transform.position = new Vector2(SaveSystem.Instance.levelGen.StartingPosition.x - SaveSystem.Instance.levelGen.moveAmountx, SaveSystem.Instance.levelGen.StartingPosition.y);
    }
}
