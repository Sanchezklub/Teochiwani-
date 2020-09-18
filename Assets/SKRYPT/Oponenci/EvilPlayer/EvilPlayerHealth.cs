using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPlayerHealth : EnemyHealth
{
    // Start is called before the first frame update
    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        base.TakeDamage(damage, attacker);
        EventController.instance.evilPlayerEvents.CallOnEvilPlayerReceiveDamage(damage, GameController.instance.DataStorage.EvilPlayerInfo.currenthealth);
    }
    protected override void Die()
    {
        base.Die();
        EventController.instance.evilPlayerEvents.CallOnPlayerDie();
    }
    protected override void Start()
    {
        MaxHealth = GameController.instance.DataStorage.EvilPlayerInfo.maxhealth;
        base.Start();
    }
}
