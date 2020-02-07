using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoaScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        CocoaCounterScript.cocoaAmount += 1;
        Destroy (gameObject);
    }

}
