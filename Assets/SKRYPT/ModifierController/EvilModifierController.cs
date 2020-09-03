using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilModifierController : ModifierController
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var mod in modifiers)
        {
            mod.Init(RemoveModifier);
        }

        EventController.instance.evilPlayerEvents.OnEvilItemPickup += OnItemPickup;
        EventController.instance.evilPlayerEvents.OnEvilWeaponPickup += OnWeaponPickup;
    }

    public override void OnItemPickup(BaseItem item)
    {
        if (item.modifiers != null)
        {
            foreach (BaseModifier mod in item.modifiers)
            {
                mod.info = GameController.instance.DataStorage.EvilPlayerInfo;
                mod.Init(RemoveModifier);
                modifiers.Add(mod);
            }
        }
    }
}
