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
    public int[] enemiesKilled = new int[200]; // pozycja na liście to id przeciwnika, wartość to liczba zabitych
    public int doubleKills;
    public float fireDamageDealt;
    public float poisonDamageDealt;
    public float bleedDamageDealt;
    public int playerDeaths;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EventController.instance.enemyEvents.OnEnemyDied += OnEnemyDied;
        EventController.instance.enemyEvents.OnBleedDamageDealt += OnBleedDamageDealt;
        EventController.instance.enemyEvents.OnFireDamageDealt += OnFireDamageDealt;
        EventController.instance.enemyEvents.OnPoisonDamageDealt += OnPoisonDamageDealt;
        EventController.instance.playerEvents.OnPlayerDie += OnPlayerDied;
        enemiesKilled = new int[100];
    }

    private void Update()
    {
        timePassed += Time.deltaTime;
    }

    void OnEnemyDied(EnemyHealth enemy)
    {
        //Debug.Log("Enemy id was " + enemy.id);
        //enemiesKilled[enemy.id] += 1;
        //StartCoroutine("MultikillTimer");

    }

    void OnPlayerDied()
    {
        playerDeaths += 1;
    }

    void OnBleedDamageDealt(float damage)
    {
        bleedDamageDealt += damage;
    }
    void OnPoisonDamageDealt(float damage)
    {
        poisonDamageDealt += damage;
    }
    void OnFireDamageDealt(float damage)
    {
        fireDamageDealt += damage;
    }

    IEnumerator MultikillTimer()
    {
        EventController.instance.enemyEvents.OnEnemyDiedBasic += OnSecondEnemyDied;
        yield return new WaitForSeconds(5);
        EventController.instance.enemyEvents.OnEnemyDiedBasic -= OnSecondEnemyDied;
    }
    void OnSecondEnemyDied()
    {
        doubleKills += 1;
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
