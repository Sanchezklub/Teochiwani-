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

    }

    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        base.TakeDamage(damage);
        enemyAnimator?.SetTrigger(Keys.TAKEDAMAGE_ANIM_KEY);
        TakingDamage?.Invoke();

    }

    public void InvokeDie()
    {
        Dying?.Invoke();
    }

    protected override void Die()
    {
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
