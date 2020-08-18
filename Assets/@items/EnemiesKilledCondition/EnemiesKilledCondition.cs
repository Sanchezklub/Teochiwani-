using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemiesKilledCondition", menuName = "Conditions/EnemiesKilledCondition", order = 5)]
public class EnemiesKilledCondition : BaseCondition
{

    public int RequiredEnemyId;
    public int RequiredAmount;
    public override bool CheckIfConditionSucesed()
    {
        return GlobalStatistics.instance.enemiesKilled[RequiredEnemyId] >= RequiredAmount;
    }
}
