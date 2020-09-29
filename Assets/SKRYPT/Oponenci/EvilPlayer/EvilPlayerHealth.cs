using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerHealth : EnemyHealth
{
    // Start is called before the first frame update
    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        GameController.instance.DataStorage.EvilPlayerInfo.currenthealth -= damage;
        //base.TakeDamage(damage, attacker);
        if (GameController.instance.DataStorage.EvilPlayerInfo.currenthealth > 0)
        {
            enemyAnimator?.SetTrigger(Keys.TAKEDAMAGE_ANIM_KEY);
        }
        TakingDamage?.Invoke();
        splashController?.MakeSplat();
        if (FloatingText == true)
        {
            ShowFloatingText(damage);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
        EventController.instance.enemyEvents.CallOnEnemyGetDamage(this);
        EventController.instance.evilPlayerEvents.CallOnEvilPlayerReceiveDamage(damage, GameController.instance.DataStorage.EvilPlayerInfo.currenthealth);
        Debug.LogFormat("Evil player took damage {0}", damage);
    }
    protected override void Die()
    {
        EventController.instance.evilPlayerEvents.CallOnPlayerDie();
        base.Die();
    }
    protected override void Start()
    {
        MaxHealth = GameController.instance.DataStorage.EvilPlayerInfo.maxhealth;
        base.Start();
    }
}
