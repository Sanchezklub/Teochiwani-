using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SaveController.LoadPlayerInfo();
    }

    public void ButtonSound()
    {
        AudioManager.instance.Play("MMClick");
    }

    public void ChangeMusic()
    {
        AudioManager.instance.Stop("Menu Theme");
        AudioManager.instance.Play("Theme");
    }

}
