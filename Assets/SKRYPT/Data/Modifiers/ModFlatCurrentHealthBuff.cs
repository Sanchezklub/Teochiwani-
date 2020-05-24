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
        GameController.instance.DataStorage.PlayerInfo.currenthealth += CurrentHealthBuff;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth -= CurrentHealthBuff;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
