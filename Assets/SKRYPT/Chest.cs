using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite mysprite1;
    private bool IsOpen=false;
    void OnCollisionStay2D()
    {
        if (IsOpen==false && Input.GetKeyDown("e") )
        {
            Debug.Log("Loot");
            IsOpen=true;
            this.GetComponent<SpriteRenderer>().sprite = mysprite1;
        }
    }
    
}
