using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedScreen : MonoBehaviour
{

    [SerializeField] private LevelDeleter deleter;
    public void ReturnToMenu()
    {
        deleter.Delete();
        GameController.instance.DataStorage.PlayerInfo.IsAlive = false;
        SaveSystem.Instance.SaveOldPlayerData();
        SaveSystem.Instance.FullySaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
