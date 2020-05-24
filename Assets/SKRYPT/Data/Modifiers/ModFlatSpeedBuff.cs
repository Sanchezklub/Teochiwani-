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
        GameController.instance.DataStorage.PlayerInfo.speed += SpeedBuff;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        GameController.instance.DataStorage.PlayerInfo.speed -= SpeedBuff;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
