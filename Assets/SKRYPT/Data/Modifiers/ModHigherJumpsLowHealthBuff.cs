using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "HigherJumpsLowHealthBuff", menuName = "Modifiers/HigherJumpsLowHealthBuff")]
public class ModHigherJumpsLowHealthBuff : BaseModifier
{
    [SerializeField]
    private float maxJumpforcePercentage;
    public float MaxJumpforcePercentage => maxJumpforcePercentage;

    private float initialJumpforce;

    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        initialJumpforce = info.jumpforce;
        AssignEvents();
        OnPlayerReceiveDamage(0, GameController.instance.DataStorage.PlayerInfo.currenthealth);
    }

    public void AssignEvents()
    {
        info.GetHitAction += OnPlayerReceiveDamage;
        info.DieAction += PlayerDied;
    }

    public void OnPlayerReceiveDamage(float damage, float healthLeft)
    {
        var maxhealth = info.maxhealth;
        var value = (1f - Mathf.InverseLerp(0f, maxhealth, healthLeft)) * (maxJumpforcePercentage/100);
        info.jumpforce = initialJumpforce + initialJumpforce * value;
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
        info.speed = initialJumpforce;
        info.GetHitAction -= OnPlayerReceiveDamage;
        info.DieAction -= PlayerDied;

        base.Deinit();
    }
}
