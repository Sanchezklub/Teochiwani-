using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private SaveSystem saveSystem;
    [SerializeField] private LevelGeneration levelGen;
    public void CheckSavefile()
    {
        int temp = SaveSystem.Instance.LoadGame();
        switch (temp)
        {
            case 0:

                LoadGame();

                break;
            case 1:

                NewGame();

                break;
            case 2:

                FirstGame();

                break;
        }
    }

    void LoadGame()
    {
        Debug.Log("StartGame :: Game was loaded");
    }

    void NewGame()
    {
        saveSystem.LoadPersistentData();
        levelGen.Create();
        Debug.Log("StartGame :: New Game was started");
    }
    void FirstGame()
    {
        levelGen.CreateTutorial();
        Debug.Log("StartGame :: New Game was started for the first time");
    }


}
