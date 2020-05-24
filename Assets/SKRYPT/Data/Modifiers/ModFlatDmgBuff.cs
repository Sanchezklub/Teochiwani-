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
        GameController.instance.DataStorage.PlayerInfo.damage += DmgBuff;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        GameController.instance.DataStorage.PlayerInfo.damage -= DmgBuff;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
