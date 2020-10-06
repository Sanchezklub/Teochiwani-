 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Experimental.Rendering.Universal; 

 public class LightChange : MonoBehaviour
 {
     public float maxRange = 11;
     public float minRange = 6;
     public float flickerSpeed = 0.5f;
 
     private Light2D lightSource;
 
     public void Start()
     {
         lightSource = GetComponent<Light2D>();
     }
 
     public void Update()
     {
         lightSource.intensity = Mathf.Lerp(minRange, maxRange, Mathf.PingPong(Time.time, flickerSpeed));
     }
 }
