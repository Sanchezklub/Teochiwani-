using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
public class LightChange : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D light;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       float  rand = (Random.Range(-100,100))/100;
       if(light.intensity>=0)
       light.intensity+=rand;
       else 
       {
        light.intensity+=Mathf.Abs(rand);
       }
    }
}
