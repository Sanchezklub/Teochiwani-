using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveContainer
{
    public PlayerDataScript playerData;
    public PlayerDataScript oldPlayerData;
    public LevelData levelData;
    public ItemsData itemsData;
    public GlobalStatisticsDataScript globalStatistics;
    public RoundStatisticsDataScript roundStatistics;
}
