using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkolopendraMoveCommand : Command
{

    private float speed;
    private Transform Raycast;

    private float StartTime;
    private float WaitTime;

    private float MinDigWaitTime;
    private float MaxDigWaitTime;

    private LayerMask WhatIsGround;
    private Rigidbody2D rb;

    private bool FacingRight;
    public SkolopendraMoveCommand(float Speed, Transform Raycast, float MinDigWaitTime, float MaxDigWaitTime, LayerMask WhatIsGround, Rigidbody2D rb)
    {
        this.speed = Speed;
        this.Raycast = Raycast;
        this.MinDigWaitTime = MinDigWaitTime;
        this.MaxDigWaitTime = MaxDigWaitTime;
        this.WhatIsGround = WhatIsGround;
        this.rb = rb;
    }

    public override void StartExecution(UnityAction<Command> OnFinishCallback)
    {
        base.StartExecution(OnFinishCallback);
        StartTime = Time.time;
        WaitTime = Random.Range(MinDigWaitTime, MaxDigWaitTime);
        DetermineIfFacingRight();
    }

    public override void UpdateExecution()
    {
        base.UpdateExecution();

        if (Physics2D.Raycast(Raycast.position, Vector2.down, 3.5f, WhatIsGround) && !Physics2D.Raycast(Raycast.position, Vector2.right, 3.5f, WhatIsGround))
        {
            Debug.Log("Skolopendra raycast hit");
            Debug.DrawRay(Raycast.position, Vector2.right * 3.5f, Color.yellow);
            Debug.DrawRay(Raycast.position, Vector2.down * 3.5f, Color.yellow);

            if (FacingRight == true)
            {
                rb.velocity = new Vector2(1 * speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
            }




        }
        else
        {
            Debug.Log("Skolopendra raycast didn't hit");
            Flip();
        }


        if (Time.time > StartTime + WaitTime)
        {
            FinishExecution();
        }
    }
    void Flip()
    {
        rb.transform.Rotate(new Vector2(0f, 180f));
        FacingRight = !FacingRight;
    }

    void DetermineIfFacingRight()
    {
        if (rb.transform.localRotation == Quaternion.Euler(0, 0, 0))
        {
            FacingRight = true;
        }
        else
        {
            FacingRight = false;
        }
    }
}
