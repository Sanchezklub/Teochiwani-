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
        if (temp == 0)
        {
            //Deleter.Delete();
            InGameUI.SetActive(true);
            Time.timeScale = 1;
            MainMenu.SetActive(false);
        }
    }
}
