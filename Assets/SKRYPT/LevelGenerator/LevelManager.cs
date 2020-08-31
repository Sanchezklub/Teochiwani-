﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private LevelDeleter deleter;
    [SerializeField] private LevelGeneration levelGen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject LoadingScreen;
    private void Start()
    {
        EventController.instance.levelEvents.OnLevelEndedBasic += OnLevelEnded;
    }

    void OnLevelEnded()
    {
        LoadingScreen.SetActive(true);
        StartCoroutine("MakeNewLevel");
    }

    IEnumerator MakeNewLevel()
    {
        yield return new WaitForSeconds(0.1f);
        deleter.Delete();
        GameController.instance.DataStorage.PlayerInfo.level = 2;
        //tutaj dać rzeczy z karmą i obecnym poziomem żeby zdecydować jaką wartość przypisać GameController.instance.DataStorage.PlayerInfo.level
        levelGen.Create();
        player.transform.position = new Vector2(SaveSystem.Instance.levelGen.StartingPosition.x - SaveSystem.Instance.levelGen.moveAmountx, SaveSystem.Instance.levelGen.StartingPosition.y);
        LoadingScreen.SetActive(false);
    }
}
