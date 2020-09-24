using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject GodsBackground;
    public GameObject JungleBackground;
    public GameObject HumanBackground;
    // Start is called before the first frame update
    void Start()
    {
        EventController.instance.levelEvents.OnChunkGeneratedBasic += Change;
    }

    void Change()
    {
        switch(GameController.instance.DataStorage.PlayerInfo.level)
        {
            case 0:
            {
                JungleBackground.SetActive(true);
                GodsBackground.SetActive(false);
                HumanBackground.SetActive(false);
                break;
            }
            case 1:
            {
                JungleBackground.SetActive(false);
                HumanBackground.SetActive(true);
                break;
            }
            case 2:
            {
                JungleBackground.SetActive(false);
                GodsBackground.SetActive(true);
                break;
            }


        }
    }
}
