using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[System.Serializable]
public class GlobalStatistics : MonoBehaviour
{
    public static GlobalStatistics instance;
    public GlobalStatisticsData data;
    public float timePassed = 0f;
    public int[] enemiesKilled; // pozycja na liście to id przeciwnika, wartość to liczba zabitych

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EventController.instance.enemyEvents.OnEnemyDied += OnEnemyDied;
        enemiesKilled = new int[100];
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
    }

    void OnEnemyDied(EnemyHealth enemy)
    {
        //Debug.Log("Enemy id was " + enemy.id);
        enemiesKilled[enemy.id] += 1;
    }

    public void SaveStatistics()
    {
        data = new GlobalStatisticsData(timePassed, enemiesKilled);
    }

    [System.Serializable]

    public class GlobalStatisticsData
    {
        public GlobalStatisticsData(float timePassed, int[] enemiesKilled)
        {
            this.timePassed = timePassed;
            this.enemiesKilled = enemiesKilled;
        }

        public float timePassed;
        public int[] enemiesKilled;
    }
}
