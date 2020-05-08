using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FasterMovement", menuName = "Modifiers/FasterMovement")]
public class ModFasterMovment : BaseModifier
{
    [SerializeField]
    private float speedPerDamage;
    public float SpeedPerDamage => speedPerDamage;

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
        var value = (1f - Mathf.InverseLerp(0f, maxhealth, healthLeft)) * speedPerDamage;
        GameController.instance.DataStorage.PlayerInfo.speed = initialSpeed + value;
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
