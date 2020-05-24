using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierController : MonoBehaviour
{
    public List<BaseModifier> modifiers;

    public void OnItemPickup(BaseItem item)
    {
        if (item.modifiers != null)
        {
            foreach (BaseModifier mod in item.modifiers)
            {
                mod.Init(RemoveModifier);
                modifiers.Add(mod);
            }
        }
    }

    public void RemoveModifier(BaseModifier mod)
    {
        modifiers.Remove(mod);
    }

    void Start()
    {
        foreach (var mod in modifiers)
        {
            mod.Init(RemoveModifier);
        }

        EventController.instance.playerEvents.OnItemPickup += OnItemPickup;
    }

    void Update()
    {
        foreach (var mod in modifiers)
        {
            mod.Update();
        }
    }

    private void OnDestroy()
    {
        foreach (var mod in modifiers)
        {
            mod.Deinit();
        }
    }
}
