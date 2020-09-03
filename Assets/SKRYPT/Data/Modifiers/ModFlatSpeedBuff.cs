using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "FlatSpeedBuff", menuName = "Modifiers/FlatSpeedBuff")]
public class ModFlatSpeedBuff : BaseModifier
{
    [SerializeField] private float SpeedBuff;



    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        info.speed += SpeedBuff;
        info.DieAction += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        info.speed -= SpeedBuff;
        info.DieAction -= PlayerDied;

        base.Deinit();
    }
}
