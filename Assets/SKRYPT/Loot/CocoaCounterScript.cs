using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CocoaCounterScript : MonoBehaviour
{
    TextMeshProUGUI text;
    public static int bloodAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void OnCocoaPickupBasic()
    {
        text.SetText(GameController.instance.DataStorage.PlayerInfo.cocoa.ToString());
    }
}
