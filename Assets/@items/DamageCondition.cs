using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageCondition", menuName = "Conditions/DamageCondition", order = 0)]
public class DamageCondition : BaseCondition
{
    public float requredDamage;

    public override bool CheckIfConditionSucesed()
    {
        return SesionStatistics.instance.damageDealt > requredDamage;
    }
}
