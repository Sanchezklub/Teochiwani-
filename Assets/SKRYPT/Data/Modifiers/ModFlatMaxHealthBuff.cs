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
        GameController.instance.DataStorage.PlayerInfo.maxhealth += MaxHealthBuff;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
        EventController.instance.playerEvents.CallOnMaxHealthValueChange(GameController.instance.DataStorage.PlayerInfo.maxhealth);
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        GameController.instance.DataStorage.PlayerInfo.maxhealth -= MaxHealthBuff;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
