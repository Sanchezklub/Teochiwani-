using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadLoader : MonoBehaviour
{
    public GameObject OnLoadUI;
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 0;
        OnLoadUI.SetActive(true);
            
    }
}
