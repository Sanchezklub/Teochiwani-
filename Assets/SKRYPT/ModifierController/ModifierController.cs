using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierController : MonoBehaviour
{
    public BaseModifier currentModifier;
   void Start()
   {
        currentModifier?.Init();     
   }

    // Update is called once per frame
    void Update()
    {
        currentModifier?.Update();
    }

    void Deinit()
    {
        currentModifier?.Deinit();
    }
}
