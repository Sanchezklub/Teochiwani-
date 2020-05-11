using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState<T>
{
    public virtual void InitState(T controller)
    {

    }
    public virtual void UpdateState()
    {

    }

    public virtual void StateOnCollisonEnter2D(Collision2D collision)
    {

    }
    public virtual void DeinitState(T controller)
    {

    }


}
