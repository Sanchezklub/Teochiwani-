using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHELPtutorial : MonoBehaviour
{
    
    public GameObject UIHelp;
    [TextArea]
    public string Text;
    public void Start()
    {
        UIHelp.GetComponent<TextMesh>().text = Text;
    }
    bool PlayerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerInRange = true;
            UIHelp.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UIHelp.SetActive(false);
        }
    }
}
