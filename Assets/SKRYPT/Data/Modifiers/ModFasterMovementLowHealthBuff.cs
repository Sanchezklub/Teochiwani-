using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FasterMovementLowHealthBuff", menuName = "Modifiers/FasterMovementLowHealthBuff")]
public class ModFasterMovementLowHealthBuff : BaseModifier
{
    [SerializeField]
    private float maxSpeedPercentage;
    public float MaxSpeedPercentage => maxSpeedPercentage;

    private float initialSpeed;

    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        initialSpeed = info.speed;
        AssignEvents();
        OnPlayerReceiveDamage(0, info.currenthealth);
    }

    public void AssignEvents()
    {
        info.GetHitAction += OnPlayerReceiveDamage;
        //EventController.instance.playerEvents.OnPlayerReceiveDamage += OnPlayerReceiveDamage;
        info.DieAction += PlayerDied;
    }

    public void OnPlayerReceiveDamage(float damage, float healthLeft)
    {
        var maxhealth = info.maxhealth;
        var value = (1f - Mathf.InverseLerp(0f, maxhealth, healthLeft)) * (maxSpeedPercentage / 100);
        info.speed = initialSpeed + initialSpeed * value;
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
        info.speed = initialSpeed;
        info.GetHitAction -= OnPlayerReceiveDamage;
        //EventController.instance.playerEvents.OnPlayerReceiveDamage -= OnPlayerReceiveDamage;
        info.DieAction -= PlayerDied;


        base.Deinit();
    }
}
