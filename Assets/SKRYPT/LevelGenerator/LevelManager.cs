using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LevelManager : MonoBehaviour
{

    [SerializeField] private LevelDeleter deleter;
    [SerializeField] private LevelGeneration levelGen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private CinemachineVirtualCamera cam;
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
        Debug.Log("Before delete");
        Debug.LogFormat("Before deleting: Enemies length is {0}. Enviros length is {1}. Etc.", SaveSystem.Instance.enemyTracker.enemies.Count, SaveSystem.Instance.enviromentTracker.enviros.Count);
        deleter.Delete();
        Debug.Log("AfterDelete");
        if ( GameController.instance.DataStorage.PlayerInfo.karma > 25)
        {
            GameController.instance.DataStorage.PlayerInfo.level=2;
        }
        else 
        {
            GameController.instance.DataStorage.PlayerInfo.level=1;
        }
        Debug.Log("After deciding level, before creating");

        Debug.LogFormat("After deleting: Enemies length is {0}. Enviros length is {1}. Etc.", SaveSystem.Instance.enemyTracker.enemies.Count, SaveSystem.Instance.enviromentTracker.enviros.Count);

        //tutaj dać rzeczy z karmą i obecnym poziomem żeby zdecydować jaką wartość przypisać GameController.instance.DataStorage.PlayerInfo.level
        yield return new WaitForSeconds(0.1f);
        
        levelGen.Create();
        Debug.LogFormat("After Creating: Enemies length is {0}. Enviros length is {1}. Etc.", SaveSystem.Instance.enemyTracker.enemies.Count, SaveSystem.Instance.enviromentTracker.enviros.Count);
        Debug.Log("After creating");

        cam.enabled = false;
        player.transform.position = new Vector2(SaveSystem.Instance.levelGen.StartingPosition.x - SaveSystem.Instance.levelGen.moveAmountx, SaveSystem.Instance.levelGen.StartingPosition.y);
        cam.enabled = true;
        LoadingScreen.SetActive(false);
    }
}
