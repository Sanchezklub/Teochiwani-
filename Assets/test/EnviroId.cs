using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnviroId : MonoBehaviour
{
   public int id;

    void Start()
    {
        
        //Debug.Log("Enviro Start");
        EventController.instance.enviromentEvents.CallOnEnviroAppear(this);
    }

    private void OnDestroy()
    {
        EventController.instance.enviromentEvents.CallOnEnviroDied(this);
    }
}
