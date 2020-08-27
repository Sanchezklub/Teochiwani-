using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FalseGodsBallState : BaseState<FalseGodsBrain>
{

    private FalseGodsBrain brain;
    private GameObject ThrownBall;
    //private Ball ThrownBallScript;
    public override void InitState(FalseGodsBrain controller)
    {
        base.DeinitState(controller);
        this.brain = controller;
        brain.Attacking += ThrowBall;
        brain.TulioAnimator.SetBool("IsThrowing", true);
        FacePlayer();
    }

    void ThrowBall()
    {
        ThrownBall = Object.Instantiate(brain.ball, brain.BallPoint.position, Quaternion.identity);
        ThrownBall.GetComponent<Ball>().Damage = brain.BallDmg;
        ThrownBall.GetComponent<Ball>().HandPosition = brain.HandTransform.position;
        ThrownBall.GetComponent<Ball>().BallDestroyed += OnBallDestroyed;
        Rigidbody2D ThrownBallrb = ThrownBall.GetComponent<Rigidbody2D>();
        if (brain.FacingRight)
        {
            ThrownBallrb.velocity = new Vector2(50, 10);
        }
        else
        {
            ThrownBallrb.velocity = new Vector2(-50, 10);
        }
    }

    void OnBallDestroyed()
    {
        brain.StartRun();
    }

    public override void DeinitState(FalseGodsBrain controller)
    {
        brain.Attacking -= ThrowBall;
        brain.TulioAnimator.SetBool("IsThrowing", false);
        base.DeinitState(controller);
    }

    public void FacePlayer()
    {
        float PositionDifference = brain.transform.position.x - GameController.instance.DataStorage.PlayerInfo.playerPosition.x;
        if (PositionDifference >= 0)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
            brain.FacingRight = false;
        }
        else if (PositionDifference <= 0)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            brain.FacingRight = true;
        }
    }

    void Flip()
    {
        brain.FacingRight = !brain.FacingRight;
        brain.transform.Rotate(new Vector2(0, 180f));
    }
}
