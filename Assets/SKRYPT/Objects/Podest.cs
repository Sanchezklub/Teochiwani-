using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podest : MonoBehaviour
{
  private PlatformEffector2D effector;
   

    void Start()
    {
    effector = GetComponent<PlatformEffector2D>();
    }
    void Update()
    {
        if ( Input.GetKeyUp(KeyCode.S))
        {
            
            effector.rotationalOffset=180f;
        }
        if ( Input.GetKey(KeyCode.Space) ||Input.GetKey(KeyCode.W) )
        {
                effector.rotationalOffset = 0;
        }
    
    
    
    
    }




}
