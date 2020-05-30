using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadGameButtonChecker : MonoBehaviour
{
    // Start is called before the first frame update
    private string path;
    private Button LoadGameButton;
    private TextMeshProUGUI text;
    
    private void Start()
    {
        path = Application.persistentDataPath + "/player.fun";
        LoadGameButton = GetComponent<Button>();
        text = LoadGameButton.GetComponentInChildren<TextMeshProUGUI>();
        
    }
    void Update()
    {
        if (!File.Exists(path))
        {
            LoadGameButton.interactable = false;
            text.color = Color.gray;
        }
        else
        {
            LoadGameButton.interactable = true;
            Color32 tempColor = new Color32(219, 219, 214, 255);
            text.color = tempColor;
        }
    }
}
