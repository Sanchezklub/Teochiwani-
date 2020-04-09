using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SpiderHealth : Health
{
    public Animator enemyAnimator;
    public UnityAction Dying;
    public UnityAction TakingDamage;
    public SpiderBrain brain;

    protected override void Start()
    {
        base.Start();

    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        enemyAnimator.SetTrigger(Keys.TAKEDAMAGE_ANIM_KEY);
        TakingDamage?.Invoke();
        if (System.String.Equals(brain.currentState.GetType() , "SpiderShootState"))
        {
            brain.StartStun();
        }

    }

    public void InvokeDie()
    {
        Dying?.Invoke();
    }

    protected override void Die()
    {
        Dying += GetDestroyed;
        base.Die();
        enemyAnimator.SetTrigger(Keys.DIE_ANIM_KEY);
    }

    public void GetDestroyed()
    {
        Destroy(gameObject);
    }
}
