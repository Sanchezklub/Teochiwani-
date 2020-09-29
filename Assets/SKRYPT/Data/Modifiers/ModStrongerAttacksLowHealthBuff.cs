using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "StrongerAttacksLowHealthBuff", menuName = "Modifiers/StrongerAttacksLowHealthBuff")]
public class ModStrongerAttacksLowHealthBuff : BaseModifier
{
    [SerializeField]
    private float maxDamagePercentage;
    public float MaxDamagePercentage => maxDamagePercentage;

    private float initialDmg;

    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        initialDmg = info.damage;
        AssignEvents();
        OnPlayerReceiveDamage(0, info.currenthealth);
    }

    public void AssignEvents()
    {
        info.GetHitAction += OnPlayerReceiveDamage;
        info.DieAction += PlayerDied;
        Debug.Log("Dusza kojota. events assigned");
    }

    public void OnPlayerReceiveDamage(float damage, float healthLeft)
    {
        Debug.Log("Dusza kojota. damage taken");
        var maxhealth = info.maxhealth;
        var value = (1f - Mathf.InverseLerp(0f, maxhealth, healthLeft)) * (maxDamagePercentage/100);
        info.damage = initialDmg + initialDmg*value;
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
        info.damage = initialDmg;
        info.GetHitAction -= OnPlayerReceiveDamage;
        info.DieAction -= PlayerDied;

        base.Deinit();
    }
}
