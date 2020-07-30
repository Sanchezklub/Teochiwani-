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
        //tutaj dać rzeczy z karmą i obecnym poziomem żeby zdecydować jaką wartość przypisać GameController.instance.DataStorage.PlayerInfo.level
        levelGen.Create();
        player.transform.position = Vector2.zero;
    }
}
