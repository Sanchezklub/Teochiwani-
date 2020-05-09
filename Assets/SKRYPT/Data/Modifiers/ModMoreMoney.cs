using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "MoreMoney", menuName = "Modifiers/MoreMoney")]
public class ModMoreMoney : BaseModifier
{
    [SerializeField]
    private int bloodMultiplier;
    public int BloodMultiplier => bloodMultiplier;

    [SerializeField]
    private int cocoaMultiplier;
    public int CocoaMultiplier => cocoaMultiplier;

    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        AssignEvents();
    }

    public void AssignEvents()
    {
        EventController.instance.playerEvents.OnBloodPickup += PickedUpBlood;
        EventController.instance.playerEvents.OnCocoaPickup += PickedUpCocoa;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }
    public void PickedUpBlood(int amount)
    {
        GameController.instance.DataStorage.PlayerInfo.blood += amount * (bloodMultiplier - 1);
    }

    public void PickedUpCocoa(int amount)
    {
        GameController.instance.DataStorage.PlayerInfo.cocoa += amount * (cocoaMultiplier - 1);
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
        EventController.instance.playerEvents.OnBloodPickup -= PickedUpBlood;
        EventController.instance.playerEvents.OnCocoaPickup -= PickedUpCocoa;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
