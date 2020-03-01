using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimeActivator : MonoBehaviour
{
    [SerializeField]
    private Security security;
    public Security Security => security;
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.Component<Ball>();
        if (ball)
        {
            security.StartFollow(ball.transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Ball ball = other.Component<Ball>();
        
         if (ball)
        {
          security.StartPatrol();  
        }
    }
}
