using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerBrain : BaseBrain<EvilPlayerBrain>
{
    public Animator animator;
    public Rigidbody2D rb;
    public Transform RaycastTransform;
    public LayerMask WhatIsGround;
    //public float damage;
    //public float speed;
    //public float jumpheight;
    public EvilPlayerCombat combat;

    public float AggroRange;
    public float AttackDist;
    public bool FacingRight;


    private void Start()
    {
        StartIdle();
    }
    public void StartIdle()
    {
        ChangeState(new EvilPlayerIdleState());
    }
    public void StartFollow()
    {
        ChangeState(new EvilPlayerIdleState());
    }

    public void StartAttack()
    {
        ChangeState(new EvilPlayerAttackState());
    }
}
