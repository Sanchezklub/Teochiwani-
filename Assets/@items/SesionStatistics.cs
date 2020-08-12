using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SesionStatistics : MonoBehaviour
{
    public static SesionStatistics instance;

    public float damageDealt;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        ResetStats();
        EventController.instance.playerEvents.OnPlayerDealDamage += OnPlayerDealDamage;
    }

    public void OnPlayerDealDamage(float damage)
    {
        damageDealt += damage;
    }

    public void Deinit()
    {
        EventController.instance.playerEvents.OnPlayerDealDamage -= OnPlayerDealDamage;
        ResetStats();
    }

    private void ResetStats()
    {
        damageDealt = 0;
    }

    [System.Serializable]
    public class RoundStatisticsData
    {
        public RoundStatisticsData(float damageTaken, List<int> enemiesKilled)
        {
            this.damageTaken = damageTaken;
            //this.enemiesKilled = enemiesKilled;
        }

        public float damageTaken;
        //public List<int> enemiesKilled;
    }
}
