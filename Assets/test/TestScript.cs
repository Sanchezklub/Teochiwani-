using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float pos_1 = GetComponent<Transform>().position.x;
        float pos_2 = GetComponent<Transform>().position.y;

        Debug.Log("The x position is"+pos_1+"The y position is" + pos_2);
    }
}
