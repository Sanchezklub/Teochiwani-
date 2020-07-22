using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBrain <T> : MonoBehaviour
{
    public BaseState<T> currentState;
    public virtual void ChangeState(BaseState<T> newState)
    {

    }
    public virtual void UpdateChildState()
    {
        if (Vector3.Distance(transform.position, GameController.instance.DataStorage.PlayerInfo.playerPosition) > 200)
        {
            return;
        }
    }

}
