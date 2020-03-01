using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Security : BaseBrain<Security>
{
    [SerializeField]
    private Transform patrolObject;
    public Transform PatrolObject => patrolObject;
    [HideInInspector]
    public Transform enemyToFollow;
    
    private void Start()
    {
        StartPatrol();
    }
    private void Update()
    {
        UpdateChildState();
    }


   public override void ChangeState(BaseState<Security> newState)
   {    
       base.ChangeState(newState);

       currentState?.DeinitState(this);
       currentState = newState;
       currentState?.InitState(this);
   }
   public override void UpdateChildState()
   {
       base.UpdateChildState();
       currentState?.UpdateState();
   }


   public void StartPatrol()
   {
       ChangeState(new PatrolState());
   }
   public void StartFollow(Transform objectToFollow)
   {
       enemyToFollow = objectToFollow;
       ChangeState (new FollowState());
   }
}
