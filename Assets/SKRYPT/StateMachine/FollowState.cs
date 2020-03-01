using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : BaseState<Security>
{
    private Security brain;


     public override void InitState(Security controller)
    {
        base.InitState(controller);
        var renderer = controller.gameObject.GetComponent<MeshRenderer>();
        renderer.material.color = Color.red;
        this.brain = controller;

    }
    public override void UpdateState()
    {
        base.UpdateState();

        brain.transform.position = Vector3.Lerp(brain.position, brain.enemyToFollow.position, Time.deltaTime * 2f);
    }
    public override void DeinitState(Security controller)
    {
        base. DeinitState(controller);
    }
}
