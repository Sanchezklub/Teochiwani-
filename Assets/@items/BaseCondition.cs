using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseCondition : ScriptableObject
{
    public int itemToUnlockid;
    public UnityAction OnConditionFulfilled;
    public virtual void Init()
    {

    }

    public virtual void UpdateCondition()
    {

    }

    public abstract bool CheckIfConditionSucesed();
}
