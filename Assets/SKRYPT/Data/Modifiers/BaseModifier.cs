using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseModifier : ScriptableObject
{
    public UnityAction<BaseModifier> OnModifierCompleted;

    public virtual void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        OnModifierCompleted += OnCompletedCallback;
    }

    public virtual void Update()
    {

    }

    public virtual void Deinit()
    {
        OnModifierCompleted = null;
    }
}
