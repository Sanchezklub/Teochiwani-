using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    public Sprite mysprite1;
    private bool Rozlane=false;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player" && Rozlane!=true)
        {
        BloodCounterScript.bloodAmount += 1;
        Destroy (gameObject);
        }
        else if (col.gameObject.layer ==8)
        {
        this.GetComponent<SpriteRenderer>().sprite = mysprite1;
        this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Rozlane = true;
        }
        
    }

}
