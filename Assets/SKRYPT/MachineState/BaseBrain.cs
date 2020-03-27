using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBrain <T> : MonoBehaviour
{
    protected BaseState<T> currentState;
    public virtual void ChangeState(BaseState<T> newState)
    {

    }
    public virtual void UpdateChildState()
    {

    }

}
