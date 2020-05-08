using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FasterMovement", menuName = "Modifiers/FasterMovement")]
public class ModFasterMovement : BaseModifier
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
        EventController.instance.playerEvents.OnPlayerRecieveDamage += OnPlayerRecieveDamage;
    }

    public void OnPlayerRecieveDamage(float damage, float healthLeft)
    {
        var currentSpeed = GameController.instance.DataStorage.PlayerInfo.speed;
        var maxhealth = GameController.instance.DataStorage.PlayerInfo.speed;
        var value = (1f - Mathf.InverseLerp(0, maxhealth, healthLeft)) * speedPerDamage;
        GameController.instance.DataStorage.PlayerInfo.speed = initialSpeed + value;
        Debug.LogFormat("<color=orange> FasterMovement() :: {0}", value);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Deinit()
    {
        base.Deinit();
        GameController.instance.DataStorage.PlayerInfo.speed = initialSpeed;
    }
}
