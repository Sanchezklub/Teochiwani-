using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destrucktable : MonoBehaviour
{
    [SerializeField] Vector2 forceDirection;
    [SerializeField] int torque;
    Rigidbody2D rb2d;

    void Start()
    {
        float randTorque = UnityEngine.Random.Range(-100,100);
        float randForceX=  UnityEngine.Random.Range(forceDirection.x-500, forceDirection.x+500);
        float randForceY=  UnityEngine.Random.Range(forceDirection.y-500, forceDirection.y+500);
        forceDirection.x=randForceX;
        forceDirection.y=randForceY;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(forceDirection);
        rb2d.AddTorque(torque);

    }

   
}
