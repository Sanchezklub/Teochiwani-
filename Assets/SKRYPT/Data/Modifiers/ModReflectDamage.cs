using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "ReflectDamage", menuName = "Modifiers/ReflectDamage")]
public class ModReflectDamage : BaseModifier
{
    [SerializeField]
    private float reflectedDamage;
    public float ReflectedDamage => reflectedDamage;

    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        AssignEvents();
    }

    public void AssignEvents()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamageWithAttacker += OnPlayerReceiveDamage;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }

    public void OnPlayerReceiveDamage(float damage, float healthLeft, GameObject attacker)
    {
        attacker?.GetComponent<Health>()?.TakeDamage(reflectedDamage);
    }

    public void PlayerDied()
    {
        Deinit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Deinit()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamageWithAttacker -= OnPlayerReceiveDamage;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
