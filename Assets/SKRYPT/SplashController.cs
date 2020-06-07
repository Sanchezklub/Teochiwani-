using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    public static SplashController instance;

    public GameObject[] splats;
    public Color[] colors;
    public ParticleSystem ps;
    private int splatOrder;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void MakeSplat()
    {
        var newSplat = Instantiate(splats[Random.Range(0, splats.Length)],transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Instantiate(ps,transform.position, Quaternion.identity);
         var newSprite = newSplat.GetComponent<SpriteRenderer>();
      // newSplat.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];

     //   splatOrder++;
      //  newSprite.sortingOrder = splatOrder;

    }
}

