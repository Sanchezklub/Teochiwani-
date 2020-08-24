using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BleedDamageCondition", menuName = "Conditions/BleedDamageCondition", order = 14)]
public class BleedDamageCondition : BaseCondition
{
    float requiredDamage;
    public override bool CheckIfConditionSucesed()
    {
        return GlobalStatistics.instance.bleedDamageDealt >= requiredDamage;
    }
}

