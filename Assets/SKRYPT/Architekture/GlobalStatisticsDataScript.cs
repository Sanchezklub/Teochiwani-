using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GlobalStatisticsDataScript
{
    public float timePassed = 0f;
    public int[] enemiesKilled; // pozycja na liście to id przeciwnika, wartość to liczba zabitych
    public int doubleKills;
    public float fireDamageDealt;
    public float poisonDamageDealt;
    public float bleedDamageDealt;
    public int playerDeaths;
    public GlobalStatisticsDataScript(GlobalStatistics stats)
    {
        this.timePassed = stats.timePassed;
        this.enemiesKilled = stats.enemiesKilled;
        this.doubleKills = stats.doubleKills;
        this.fireDamageDealt = stats.fireDamageDealt;
        this.poisonDamageDealt = stats.poisonDamageDealt;
        this.bleedDamageDealt = stats.bleedDamageDealt;
        this.playerDeaths = stats.playerDeaths;
    }
}
