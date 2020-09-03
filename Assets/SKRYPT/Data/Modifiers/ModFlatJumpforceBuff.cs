using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "FlatJumpforceBuff", menuName = "Modifiers/FlatJumpforceBuff")]
public class ModFlatJumpforceBuff : BaseModifier
{
    [SerializeField] private float JumpforceBuff;



    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        info.jumpforce += JumpforceBuff;
        info.DieAction += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        info.jumpforce -= JumpforceBuff;
        info.DieAction -= PlayerDied;

        base.Deinit();
    }
}
