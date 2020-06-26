using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GlobalStatistics : MonoBehaviour
{
    public static GlobalStatistics instance;

    public float timePassed;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        timePassed = Time.realtimeSinceStartup;
    }
}
