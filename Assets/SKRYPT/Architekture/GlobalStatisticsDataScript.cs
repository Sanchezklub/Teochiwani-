using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalStatisticsDataScript
{
    public float timePassed = 0f;
    public int[] enemiesKilled; // pozycja na liście to id przeciwnika, wartość to liczba zabitych

    public GlobalStatisticsDataScript(GlobalStatistics stats)
    {
        this.timePassed = stats.timePassed;
        this.enemiesKilled = stats.enemiesKilled;
    }
}
