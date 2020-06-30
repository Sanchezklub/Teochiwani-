using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageTakenCondition", menuName = "Conditions/DamageTakenCondition", order = 2)]
public class DamageTakenCondition : BaseCondition
{
    public float MaximumDamageToTake;

    public override bool CheckIfConditionSucesed()
    {
        return RoundStatistics.instance.damageTaken <= MaximumDamageToTake;
    }
}
