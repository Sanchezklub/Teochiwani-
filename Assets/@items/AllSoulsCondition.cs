using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllSoulsCondition", menuName = "Conditions/AllSoulsCondition", order = 11)]
public class AllSoulsCondition : BaseCondition
{
    public override bool CheckIfConditionSucesed()
    {
        var ids = GameController.instance.DataStorage.PlayerInfo.ItemIDs;
        return (ids.Contains(11) && ids.Contains(12) && ids.Contains(13) && ids.Contains(14));
    }
}
