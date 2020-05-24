using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FasterMovementLowHealthBuff", menuName = "Modifiers/FasterMovementLowHealthBuff")]
public class ModFasterMovmentLowHealthBuff : BaseModifier
{
    [SerializeField]
    private float maxSpeedboostPercentage;
    public float MaxSpeedboostPercentage => maxSpeedboostPercentage;

    private float initialSpeed;

    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        initialSpeed = GameController.instance.DataStorage.PlayerInfo.speed;
        AssignEvents();
    }

    public void AssignEvents()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage += OnPlayerReceiveDamage;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }

    public void OnPlayerReceiveDamage(float damage, float healthLeft)
    {
        var maxhealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        var value = (1f - Mathf.InverseLerp(0f, maxhealth, healthLeft)) * (maxSpeedboostPercentage/100);
        GameController.instance.DataStorage.PlayerInfo.speed = initialSpeed + value*initialSpeed;
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
        GameController.instance.DataStorage.PlayerInfo.speed = initialSpeed;
        EventController.instance.playerEvents.OnPlayerReceiveDamage -= OnPlayerReceiveDamage;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
