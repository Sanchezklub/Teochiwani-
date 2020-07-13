using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGodsEvents : MonoBehaviour
{
    private FalseGodsBrain brain;
    private void Start()
    {
        brain = GetComponentInParent<FalseGodsBrain>();
    }


    public void ActionAttack()
    {
        brain.ActionAttack();
    }

    public void ActionEndAttack()
    {
        brain.ActionEndAttack();
    }
}
