using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetroyTrue : MonoBehaviour
{
    public float Destroytime =3f;
    public Vector3 Offset = new Vector3(0,2,0);
    public Vector3 RandomizeIntensity = new Vector3(1,0,0);
    void Start()
    {
        Destroy(gameObject,Destroytime);
        transform.localPosition +=Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x),Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),0 );
    }
}
