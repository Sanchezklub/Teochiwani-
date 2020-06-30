using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FalseGodsBallState : BaseState<FalseGodsBrain>
{

    private FalseGodsBrain brain;
    private GameObject ThrownBall;
    private Ball ThrownBallScript;
    public override void InitState(FalseGodsBrain controller)
    {
        base.DeinitState(controller);
        this.brain = controller;
        ThrowBall();
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
}
