using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeathCondition", menuName = "Conditions/DeathCondition", order = 16)]

public class DeathCondition : BaseCondition
{
    int requiredDeaths;

    public override bool CheckIfConditionSucesed()
    {
        return GlobalStatistics.instance.playerDeaths >= requiredDeaths;
    }
}
