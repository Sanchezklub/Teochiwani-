using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "ModFlatAttackSpeed", menuName = "Modifiers/FlatAttackSpeed")]
public class ModFlatAttackSpeed : BaseModifier
{
     [SerializeField] private float AttackSpeedBuff;

    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        info.attackspeed += AttackSpeedBuff;
        info.DieAction += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        info.attackspeed -= AttackSpeedBuff;
        info.DieAction -= PlayerDied;

        base.Deinit();
    }
}
