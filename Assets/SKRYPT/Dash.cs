using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Rigidbody2D PlayerRigidbody;
    public float DashSpeed;
    public float DashTime;
    public float StartDashTime;
    public int direction;

    
    // Start is called before the first frame update
    void Start()
    {
        DashTime = StartDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if ( direction == 0 )
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                direction =1;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                direction = 2;
            }
        }
        else 
        {
            if (DashTime <=0)
            {
                direction =0;
                DashTime = StartDashTime;
                PlayerRigidbody.velocity = Vector2.zero;
            }
            else 
            {
                DashTime -=Time.deltaTime;
                if ( direction ==1 )
                {
                    PlayerRigidbody.velocity = Vector2.left * DashSpeed;
                }
                else if( direction==2 )
                {
                    PlayerRigidbody.velocity = Vector2.right * DashSpeed;
                }
            }

        }


    }
}
