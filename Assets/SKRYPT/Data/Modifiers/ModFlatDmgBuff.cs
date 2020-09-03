using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "FlatDmgBuff", menuName = "Modifiers/FlatDmgBuff")]
public class ModFlatDmgBuff : BaseModifier
{
    [SerializeField] private float DmgBuff;



    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        info.damage += DmgBuff;
        info.DieAction+= PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        info.damage -= DmgBuff;
        info.DieAction -= PlayerDied;

        base.Deinit();
    }
}
