using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisonDamageCondition", menuName = "Conditions/PoisonDamageCondition", order = 13)]
public class PoisonDamageCondition : BaseCondition
{
    float requiredDamage;
    public override bool CheckIfConditionSucesed()
    {
        return GlobalStatistics.instance.poisonDamageDealt >= requiredDamage;
    }
}
