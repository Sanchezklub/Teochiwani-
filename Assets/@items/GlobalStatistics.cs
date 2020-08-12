using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GlobalStatistics : MonoBehaviour
{
    public static GlobalStatistics instance;

    public float timePassed;
    public List<int> enemiesKilled; // pozycja na liście to id przeciwnika, wartość to liczba zabitych

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EventController.instance.enemyEvents.OnEnemyDied += OnEnemyDied;
    }

    private void Update()
    {
        timePassed = Time.realtimeSinceStartup;
    }

    void OnEnemyDied(EnemyHealth enemy)
    {
        enemiesKilled[enemy.id] += 1;
    }
    [System.Serializable]

    public class GlobalStatisticsData
    {
        public GlobalStatisticsData(float timePassed, List<int> enemiesKilled)
        {
            this.timePassed = timePassed;
            this.enemiesKilled = enemiesKilled;
        }

        public float timePassed;
        public List<int> enemiesKilled;
    }
}

}
