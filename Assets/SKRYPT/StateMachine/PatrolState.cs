using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState<Security>
{
    private Security brain;
    
    
    public override void InitState(Security controller)
    {
        base.InitState(controller);
        var renderer = controller.gameObject.GetComponent<MeshRenderer>();
        renderer.material.color = Color.green;
        this.brain=controller;

    }
    public override void UpdateState()
    {
        base.UpdateState();

        if(Vector3.Distance(brain.PatrolObject.position, brain.transform.position) > 1.5f )
        {
            brain.transform.position = Vector3.Lerp(brain.transform.position, brain.PatrolObject, Time.deltaTime *2f);
        }
        brain.transform.RotateAround(brain.PatrolObject.position, Vector3.up, 1f);
    }
    public override void DeinitState(Security controller)
    {
        base. DeinitState(controller);
    }
}
