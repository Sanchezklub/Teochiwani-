
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "FlatHealthBuff", menuName = "Modifiers/FlatHealthBuff")]
public class ModHealthBuff : BaseModifier
{
    [SerializeField] private float HealthBuff;



    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        if( GameController.instance.DataStorage.PlayerInfo.currenthealth < GameController.instance.DataStorage.PlayerInfo.maxhealth)
        {
            GameController.instance.DataStorage.PlayerInfo.currenthealth += HealthBuff;
            if ( GameController.instance.DataStorage.PlayerInfo.currenthealth >= GameController.instance.DataStorage.PlayerInfo.maxhealth)
            {
                GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
            }
            
            EventController.instance.playerEvents.OnPlayerDie += PlayerDied;

        }
    
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth -= HealthBuff;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}

