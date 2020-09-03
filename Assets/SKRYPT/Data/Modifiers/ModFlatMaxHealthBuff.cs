using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "FlatMaxHealthBuff", menuName = "Modifiers/FlatMaxHealthBuff")]
public class ModFlatMaxHealthBuff : BaseModifier
{
    [SerializeField] private float MaxHealthBuff;



    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        info.maxhealth += MaxHealthBuff;
        EventController.instance.playerEvents.CallOnMaxhealthValueChange(MaxHealthBuff);
        info.DieAction += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        info.maxhealth -= MaxHealthBuff;
        info.DieAction -= PlayerDied;

        base.Deinit();
    }
}
