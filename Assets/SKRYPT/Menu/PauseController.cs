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
                AudioManager.instance.MuteSounds();
                Pause();
            }
            else
            {
                AudioManager.instance.UnMuteSounds();
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
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
