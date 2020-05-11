using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public bool IsPaused;
    public GameObject PauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        IsPaused = true;
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        PauseMenuUI.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1;
    }

    public void ReturnToMainMenu()
    {
        Unpause();
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
