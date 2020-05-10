using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "MoneyToDmg", menuName = "Modifiers/MoneyToDmg")]
public class ModMoneyToDmg : BaseModifier
{
    [SerializeField]
    private float moneyPerDamage;
    public float MoneyPerDamage => moneyPerDamage;

    private float initialDmg;
    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        AssignEvents();
        initialDmg = GameController.instance.DataStorage.PlayerInfo.damage;
        PickedUpMoney();
    }

    public void AssignEvents()
    {
        EventController.instance.playerEvents.OnBloodPickupBasic += PickedUpMoney;
        EventController.instance.playerEvents.OnBloodLostBasic += PickedUpMoney;
        EventController.instance.playerEvents.OnCocoaPickupBasic += PickedUpMoney;
        EventController.instance.playerEvents.OnCocoaLostBasic += PickedUpMoney;

        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }
    public void PickedUpMoney()
    {
        Debug.Log("PickedUpMoney :: ModMoneyToDmg");
        var blood = GameController.instance.DataStorage.PlayerInfo.blood;
        var cocoa = GameController.instance.DataStorage.PlayerInfo.cocoa;
        GameController.instance.DataStorage.PlayerInfo.damage = initialDmg + ((blood + cocoa) / MoneyPerDamage);
    }


    public void PlayerDied()
    {
        Deinit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Deinit()
    {
        EventController.instance.playerEvents.OnBloodPickupBasic -= PickedUpMoney;
        EventController.instance.playerEvents.OnBloodLostBasic -= PickedUpMoney;
        EventController.instance.playerEvents.OnCocoaPickupBasic -= PickedUpMoney;
        EventController.instance.playerEvents.OnCocoaLostBasic -= PickedUpMoney;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
