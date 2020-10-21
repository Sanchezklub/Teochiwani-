using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Vampiric", menuName = "WeaponModifiers/Vampiric")]
public class VampiricWeaponModifier : BaseWeaponModifier
{
    void OnPlayerDealDamage(float damage)
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth+=damage;
        Debug.Log("VampiricWeaponModifier :: Health was drained");
    }
    public override void Apply(BaseWeapon weapon)
    {
        base.Apply(weapon);
        EventController.instance.playerEvents.OnPlayerDealDamage += OnPlayerDealDamage;
    }

    public override void Remove(BaseWeapon weapon)
    {
        base.Remove(weapon);
        EventController.instance.playerEvents.OnPlayerDealDamage -= OnPlayerDealDamage;
    }
}
