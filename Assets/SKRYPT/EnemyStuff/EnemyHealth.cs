using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    public Animator enemyAnimator;
    public UnityAction Dying;
    public UnityAction TakingDamage;
    public bool IsHuman;
    public GameObject this1;
    public Transform temp;
    public GameObject[] Limbs;
    public GameObject[] Limbs2;
    protected override void Start()
    {
        base.Start();

        EventController.instance.enemyEvents.CallOnEnemyAppear(this);
    }

    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        base.TakeDamage(damage);
        if (currentHealth > 0)
        {
            enemyAnimator?.SetTrigger(Keys.TAKEDAMAGE_ANIM_KEY);
        }
        TakingDamage?.Invoke();
        EventController.instance.enemyEvents.CallOnEnemyGetDamage(this);

    }

    public void InvokeDie()
    {
        Dying?.Invoke();
    }

    protected override void Die()
    {
        int rand;
        rand = Random.Range(0,100);
        if (rand > - 1)
        {
        int rand1 = Random.Range(0, Limbs.Length);
        Debug.Log(Limbs[rand1].transform.position);
        Debug.Log(Limbs[rand1].transform.localPosition);
        Limbs[rand1].transform.parent=null;
        Limbs2[rand1].transform.parent=null;
        Rigidbody2D gameObjectsRigidBody = Limbs[rand1].AddComponent<Rigidbody2D>(); 
        Debug.Log(Limbs[rand1].transform.position);
        Debug.Log(Limbs[rand1].transform.localPosition);
        //Limbs[rand1].transform.position = this1.transform.position;
        }
        EventController.instance.enemyEvents.CallOnEnemyDied(this);
        Dying += GetDestroyed;
        base.Die();
        if (enemyAnimator == null)
        {
            Destroy(gameObject);
        }
        else
        {
            enemyAnimator.SetTrigger(Keys.DIE_ANIM_KEY);
        }

        if (IsHuman)// Dodawanie i odejmowanie karmy w zależności czy przeciwnik jest human czy nie. Karma min 0, max 50, start 25, zmiana o 1.

            GameController.instance.DataStorage.PlayerInfo.karma -= 1;

        else

            GameController.instance.DataStorage.PlayerInfo.karma += 1;



    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }

}
