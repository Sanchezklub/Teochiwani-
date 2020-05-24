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
        GameController.instance.DataStorage.PlayerInfo.jumpforce += JumpforceBuff;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        GameController.instance.DataStorage.PlayerInfo.jumpforce -= JumpforceBuff;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
