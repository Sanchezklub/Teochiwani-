using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{ 
    public Animator enemyAnimator;
    public UnityAction Dying;
    public UnityAction TakingDamage;

    protected override void Start()
    {
        base.Start();

        EventController.instance.enemyEvents.CallOnEnemyAppear(this);
    }

    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        base.TakeDamage(damage);
        TakingDamage?.Invoke();
        enemyAnimator?.SetTrigger(Keys.TAKEDAMAGE_ANIM_KEY);

    }

    public void InvokeDie()
    {
        Dying?.Invoke();
    }

    protected override void Die()
    {
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
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }

}
