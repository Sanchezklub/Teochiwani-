using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    public static SplashController instance;

    public GameObject[] splats;
    public ParticleSystem ps;
    private int splatOrder;
    public GameObject BloodSplitter;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void MakeSplat()
    {
        var newSplat = Instantiate(splats[Random.Range(0, splats.Length)],transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Instantiate(ps,BloodSplitter.transform.position, Quaternion.identity);
    }
}

