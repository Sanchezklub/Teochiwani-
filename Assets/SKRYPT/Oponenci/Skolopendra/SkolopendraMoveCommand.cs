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
    }

    public override void UpdateExecution()
    {
        base.UpdateExecution();

        if (Physics2D.Raycast(Raycast.position, Vector2.down, 2f, WhatIsGround) && !Physics2D.Raycast(Raycast.position, Vector2.right, 2f, WhatIsGround))
        {

            //Debug.DrawRay(brain.raycastTransform.position, Vector2.down * hit.distance, Color.yellow);

            //Debug.Log("Did Hit");
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
}
