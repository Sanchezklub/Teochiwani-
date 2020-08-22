using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoublekillCondition", menuName = "Conditions/DoublekillCondition", order = 6)]
public class DoublekillCondition : BaseCondition
{
    [SerializeField] private int RequiredMultikills;
    public override bool CheckIfConditionSucesed()
    {
        return GlobalStatistics.instance.doubleKills >= RequiredMultikills;
    }
}
