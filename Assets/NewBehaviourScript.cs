using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBahviourScript : MonoBehaviour
{
   
    bool Otwarta=false;

   
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObcjet.CompareTag("Skrzynia")&& Input.GetKeyDown ( "E") && Otwarta==false)
        {
         //   other.sortingOrder=0;
            Otwarta=true;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
