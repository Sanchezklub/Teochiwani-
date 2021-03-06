﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    //public static SplashController instance;

    public GameObject[] splats;
    [SerializeField] private ParticleSystem ps;
    private int splatOrder;
    public GameObject BloodSplitter;
    private GameObject newSplat;
    // Start is called before the first frame update
    //void Start()
    //{
    //    instance = this;
    //}
    
        
    
    public void MakeSplat()
    {
        if (ps != null)
        {
             newSplat = Instantiate(splats[Random.Range(0, splats.Length)], transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Instantiate(ps, BloodSplitter.transform.position, Quaternion.identity);
            Destroy(newSplat,90);
        }

    }
}

