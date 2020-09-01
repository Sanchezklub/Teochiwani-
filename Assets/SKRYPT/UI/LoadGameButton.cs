using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameButton : MonoBehaviour
{

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject InGameUI;
    [SerializeField] LevelDeleter Deleter;
    [SerializeField]
    public void OnClick()
    {
        int temp = SaveSystem.Instance.LoadGame();
        Debug.Log("save system 6");
        if (temp == 0)
        {
            //Deleter.Delete();
            InGameUI.SetActive(true);
            Debug.Log("save system 7");
            Time.timeScale = 1;
            MainMenu.SetActive(false);
        }
    }
}
