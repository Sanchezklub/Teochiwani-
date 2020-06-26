using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TimeCondition", menuName = "Conditions/TimeCondition", order = 0)]
public class TimeCondition : BaseCondition
{
    public float requredTimeToSpend;

    public override bool CheckIfConditionSucesed()
    {
        return GlobalStatistics.instance.timePassed > requredTimeToSpend;
    }
}
