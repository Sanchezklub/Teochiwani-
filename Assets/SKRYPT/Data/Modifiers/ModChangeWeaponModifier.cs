using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "ModChangeWeaponModifier", menuName = "Modifiers/ModChangeWeaponModifier")]
public class ModChangeWeaponModifier : BaseModifier
{

    [SerializeField] private int NewModId;
    private int OldModId;
    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        ModifyWeapon();
    }

    void ModifyWeapon()
    {
        BaseWeapon weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().currentWeapon;
        OldModId = weapon.ModId;
        weapon.ChangeModifier(NewModId);
    }

    public override void Deinit()
    {
        BaseWeapon weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>().currentWeapon;
        weapon.ChangeModifier(OldModId);
        base.Deinit();

    }
}
