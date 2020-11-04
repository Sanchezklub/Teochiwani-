using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    [SerializeField] private SaveSystem saveSystem;
    [SerializeField] private LevelGeneration levelGen;
    [SerializeField] private LevelDeleter deleter;
    [SerializeField] private GameObject errorText;


    [SerializeField] private MainMenu menuScript;
    [SerializeField] private StopTimestop timestop;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private TimerController timer;

    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject InGameUI;

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
            case 3:
                StartCoroutine("LoadingWentWrong");
                break;
        }
    }

    void LoadGame()
    {
        Debug.Log("StartGame :: Game was loaded");
        DoTheRest();
    }

    void NewGame()
    {
        saveSystem.LoadPersistentData();
        levelGen.Create();
        DoTheRest();
        Debug.Log("StartGame :: New Game was started");
    }
    void FirstGame()
    {
        levelGen.CreateTutorial();
        DoTheRest();
        Debug.Log("StartGame :: New Game was started for the first time");
    }

    IEnumerator LoadingWentWrong()
    {
        deleter.Delete();
        ShowErrrorText();
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void ShowErrrorText()
    {
        errorText.SetActive(true);
    }

    void DoTheRest()
    {
        menuScript.ChangeMusic();
        musicManager.ChangeTheme1();
        InGameUI.SetActive(true);
        timestop.StopTimestopFunction();
        MainMenu.SetActive(false);
        timer.BeginTimer();

    }

}
