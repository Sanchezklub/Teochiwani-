using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splat : MonoBehaviour
{
    public SpriteRenderer sr;
    public Color[] colors;
    public void Update()
    {

        sr.color=colors[Random.Range(0, colors.Length)];
    
    }
}
