using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "FlatCurrentHealthBuff", menuName = "Modifiers/FlatCurrentHealthBuff")]
public class ModFlatCurrentHealthBuff : BaseModifier
{
    [SerializeField] private float CurrentHealthBuff;



    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        info.currenthealth += CurrentHealthBuff;
        info.DieAction += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        info.currenthealth -= CurrentHealthBuff;
        info.DieAction -= PlayerDied;

        base.Deinit();
    }
}
