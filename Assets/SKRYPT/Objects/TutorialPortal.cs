using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.DataStorage.PlayerInfo.portalPosition = transform.position;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SaveSystem.Instance.SaveGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
