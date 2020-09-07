using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promien : MonoBehaviour
{
    private RectTransform rectTransform;
    public float Rotationspeed;
    public bool rotateRight;
    void Start ()
    {
     rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 rotation = rectTransform.rotation;
        if( rotateRight)
        {
            rectTransform.Rotate( new Vector3( 0, 0, Rotationspeed ) );
        }
        else
        {
            rectTransform.Rotate( new Vector3( 0, 0, -Rotationspeed ) );
        }
    }
}
