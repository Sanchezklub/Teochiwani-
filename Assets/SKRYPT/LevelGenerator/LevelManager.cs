using System.Collections;
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
        yield return new WaitForSeconds(5f);
        Debug.Log("Before delete");
        deleter.Delete();
        yield return new WaitForSeconds(3f);
        if ( GameController.instance.DataStorage.PlayerInfo.karma > 25)
        {
            GameController.instance.DataStorage.PlayerInfo.level=2;
        }
        else 
        {
            GameController.instance.DataStorage.PlayerInfo.level=1;
        }
        Debug.Log("After deciding level, before creating");
        //tutaj dać rzeczy z karmą i obecnym poziomem żeby zdecydować jaką wartość przypisać GameController.instance.DataStorage.PlayerInfo.level
        levelGen.Create();
        yield return new WaitForSeconds(3f);
        player.transform.position = new Vector2(SaveSystem.Instance.levelGen.StartingPosition.x - SaveSystem.Instance.levelGen.moveAmountx, SaveSystem.Instance.levelGen.StartingPosition.y);
        LoadingScreen.SetActive(false);
    }
}
