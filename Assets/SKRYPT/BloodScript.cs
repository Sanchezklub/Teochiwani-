using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        BloodCounterScript.bloodAmount += 1;
        Destroy (gameObject);
    }

}
