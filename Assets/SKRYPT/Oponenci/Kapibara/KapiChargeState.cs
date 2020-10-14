using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class KapiChargeState : BaseState<KapiBrain>
{
    private KapiBrain brain;
    private GameObject player;
    Rigidbody2D enemyRigidBody2D;
    private Material OldMaterial;

    float PositionDifference;
    public override void InitState(KapiBrain controller)
    {
        base.InitState(controller);
        this.brain = controller;
        //brain.enemyAnimator.SetBool("Idle", false);
        //brain.enemyAnimator.SetBool("Charge", true);

        player = GameObject.Find("Player");
        enemyRigidBody2D = brain.GetComponent<Rigidbody2D>();
        if (!brain.ChargeHitbox.activeSelf)
        {
            brain.ChargeHitbox.SetActive(true);
        }

        brain.enemyAnimator.SetBool("isCharging", true);
        brain.enemyAnimator.SetBool("isIdle", false);
        //brain.SoundAttack();
        AudioManager.instance.Play("Capybara Attack");
        StartCharge();
    }

    public void StartCharge()
    {

        PositionDifference = brain.transform.position.x - player.transform.position.x;
        if (PositionDifference >= 0)
        {
            if (brain.FacingRight)
            {
                Flip();
            }
            enemyRigidBody2D.velocity = new Vector2(-1 * brain.speed, enemyRigidBody2D.velocity.y);
        }
        else if (PositionDifference <= 0)
        {
            if (!brain.FacingRight)
            {
                Flip();
            }
            enemyRigidBody2D.velocity = new Vector2(1 * brain.speed, enemyRigidBody2D.velocity.y);
        }
        TurnRed();
        /*
        foreach(GameObject limb in brain.health.Limbs)
        {
            OldMaterial = limb.GetComponent<SpriteRenderer>().material;
            if (limb.GetComponent<SpriteRenderer>().material != brain.health.LightningEffectMaterial)
            {
                limb.GetComponent<SpriteRenderer>().material = brain.FlashMaterial;
                limb.GetComponent<SpriteRenderer>().material.SetColor("Flash Color", Color.red);
                limb.GetComponent<SpriteRenderer>().material.SetFloat("Flash Amount", 0.2f);
            }
        }
        */
    }

    void TurnRed()
    {
        Debug.Log("Kapibara attempted to turn red");
        foreach (GameObject limb in brain.health.Limbs)
        {
            OldMaterial = limb.GetComponent<SpriteRenderer>().material;
            if (limb.GetComponent<SpriteRenderer>().material != brain.health.LightningEffectMaterial)
            {
                limb.GetComponent<SpriteRenderer>().material = brain.FlashMaterial;
                limb.GetComponent<SpriteRenderer>().material.SetColor("_FlashColor", Color.red);
                limb.GetComponent<SpriteRenderer>().material.SetFloat("_FlashAmount", 0.2f);
            }
        }
    }

    void Flip()
    {
        brain.transform.Rotate(new Vector2(0f, 180f));
        brain.FacingRight = !brain.FacingRight;
    }

    public override void UpdateState()
    {
        KeepCharging();
        DistanceCheck();
    }

    void KeepCharging()
    {
        if (brain.FacingRight == true)
        {
            enemyRigidBody2D.velocity = new Vector2(1 * brain.speed, enemyRigidBody2D.velocity.y);
        }
        else
        {
            enemyRigidBody2D.velocity = new Vector2(-1 * brain.speed, enemyRigidBody2D.velocity.y);
        }
    }
    void DistanceCheck()
    {
        if( Vector3.Distance(brain.transform.position, GameController.instance.DataStorage.PlayerInfo.playerPosition )> brain.StopChargeDist)
        {
            brain.StartChannelling();
        }
    }

    public override void DeinitState(KapiBrain controller)
    {
        base.DeinitState(controller);
        brain.ChargeHitbox.SetActive(false);
        //brain.enemyAnimator.SetBool("Idle", true);
        //brain.enemyAnimator.SetBool("Charge", false);
        foreach (GameObject limb in brain.health.Limbs)
        {
            limb.GetComponent<SpriteRenderer>().material = OldMaterial;
        }
    }


}
