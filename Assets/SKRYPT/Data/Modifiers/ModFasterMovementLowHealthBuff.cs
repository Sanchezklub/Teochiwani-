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
        initialSpeed = GameController.instance.DataStorage.PlayerInfo.speed;
        AssignEvents();
        OnPlayerReceiveDamage(0, GameController.instance.DataStorage.PlayerInfo.currenthealth);
    }

    public void AssignEvents()
    {
        info.GetHitAction += OnPlayerReceiveDamage;
        //EventController.instance.playerEvents.OnPlayerReceiveDamage += OnPlayerReceiveDamage;
        info.DieAction += PlayerDied;
    }

    public void OnPlayerReceiveDamage(float damage, float healthLeft)
    {
        var maxhealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        var value = (1f - Mathf.InverseLerp(0f, maxhealth, healthLeft)) * (maxSpeedPercentage / 100);
        GameController.instance.DataStorage.PlayerInfo.speed = initialSpeed + initialSpeed * value;
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
        info.GetHitAction -= OnPlayerReceiveDamage;
        //EventController.instance.playerEvents.OnPlayerReceiveDamage -= OnPlayerReceiveDamage;
        info.DieAction -= PlayerDied;


        base.Deinit();
    }
}
