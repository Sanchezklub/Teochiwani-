using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FreeCondition", menuName = "Conditions/FreeCondition", order = 3)]
public class FreeCondition : BaseCondition
{
    public override bool CheckIfConditionSucesed()
    {
        return true;
    }
}
