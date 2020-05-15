using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentTracker : MonoBehaviour
{
    public List<EnviroId> enviros = new List<EnviroId>();

    public void Awake()
    {
        EventController.instance.enviromentEvents.OnEnviroAppear += OnNewEnviro;
        EventController.instance.enviromentEvents.OnEnviroDied += OnEnviroDie;
    }

    public void OnNewEnviro(EnviroId newEnviro)
    {
        Debug.Log("NewEnviro");
        enviros.Add(newEnviro);
    }

    public void OnEnviroDie(EnviroId enviro)
    {
        enviros.Remove(enviro);
    }

    private void OnApplicationQuit()
    {
        EventController.instance.enviromentEvents.OnEnviroAppear -= OnNewEnviro;
        EventController.instance.enviromentEvents.OnEnviroDied -= OnEnviroDie;
    }
}
