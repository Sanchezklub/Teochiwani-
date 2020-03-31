using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodCounterScript : MonoBehaviour
{
    Text text;
    public static int bloodAmount;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text> ();
       
    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameController.instance.DataStorage.PlayerInfo.blood.ToString();   
    }
}
