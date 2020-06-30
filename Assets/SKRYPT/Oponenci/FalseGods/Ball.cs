using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Ball : MonoBehaviour
{
    int BounceCounter;
    public Vector2 HandPosition;
    private Vector2 ReturnPosition;
    public float Damage;
    private float StartReturnTime;
    private bool returning = false;

    public UnityAction BallDestroyed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BounceCounter += 1;
        if (BounceCounter == 3)
        {
            ReturnPosition = transform.position;
            StartReturnTime = Time.time;
            returning = true;
        }
    }

    private void Update()
    {
        if (returning)
        {
            float Value = (Time.time - StartReturnTime) / 0.75f;
            Debug.Log("Value is" + Value);
            if (Value >= 1)
            {
                CallOnBallDestroyed();
                Destroy(gameObject);
            }
            this.transform.position = Vector2.Lerp(ReturnPosition, HandPosition, Value);
        }
    }

    private void CallOnBallDestroyed()
    {
        BallDestroyed?.Invoke();
    }


}
