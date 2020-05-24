using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    public static SplashController instance;

    public GameObject[] splats;
    public Color[] colors;

    private int splatOrder;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            MakeSplat();
        }
    }


    public void MakeSplat()
    {
        var newSplat = Instantiate(splats[Random.Range(0, splats.Length)], GameController.instance.DataStorage.PlayerInfo.playerPosition, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        var newSprite = newSplat.GetComponent<SpriteRenderer>();
        newSprite.color = colors[Random.Range(0, colors.Length)];

        splatOrder++;
        newSprite.sortingOrder = splatOrder;

    }
}

