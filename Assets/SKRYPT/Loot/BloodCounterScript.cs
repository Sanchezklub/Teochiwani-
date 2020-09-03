using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BloodCounterScript : MonoBehaviour
{
    TextMeshProUGUI text;
    public static int bloodAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI> ();
       
    }

    // Update is called once per frame
    void OnBloodPickupBasic()
    {
        text.SetText(GameController.instance.DataStorage.PlayerInfo.blood.ToString());   
    }
}
