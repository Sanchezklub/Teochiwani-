using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireDamageCondition", menuName = "Conditions/FireDamageCondition", order = 12)]
public class FireDamageCondition : BaseCondition
{
    float requiredDamage;
    public override bool CheckIfConditionSucesed()
    {
        return GlobalStatistics.instance.fireDamageDealt >= requiredDamage;
    }
}
