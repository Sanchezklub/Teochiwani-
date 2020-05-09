using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StrongerAttacks", menuName = "Modifiers/StrongerAttacks")]
public class ModStrongerAttacks : BaseModifier
{
    [SerializeField]
    private float maxDamagePercentage;
    public float MaxDamagePercentage => maxDamagePercentage;

    private float initialDmg;

    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        initialDmg = GameController.instance.DataStorage.PlayerInfo.damage;
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
        var value = (1f - Mathf.InverseLerp(0f, maxhealth, healthLeft)) * (maxDamagePercentage/100);
        GameController.instance.DataStorage.PlayerInfo.damage = initialDmg + initialDmg*value;
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
        GameController.instance.DataStorage.PlayerInfo.damage = initialDmg;
        EventController.instance.playerEvents.OnPlayerReceiveDamage -= OnPlayerReceiveDamage;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
