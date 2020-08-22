using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoundStatisticsDataScript
{

    public float damageTaken;
    public int[] enemiesKilled; // pozycja na liście to id przeciwnika, wartość to liczba zabitych

    public RoundStatisticsDataScript(RoundStatistics RoundStats)
    {
        this.damageTaken = RoundStats.damageTaken;
        this.enemiesKilled = RoundStats.enemiesKilled;
    }


}