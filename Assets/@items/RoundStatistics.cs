using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStatistics : MonoBehaviour
{
    // Start is called before the first frame update
    public static RoundStatistics instance;
    
    public float damageTaken;
    public List<int> enemiesKilled; // pozycja na liście to id przeciwnika, wartość to liczba zabitych

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ResetStats();
        EventController.instance.enemyEvents.OnEnemyDied += OnEnemyDied;
        EventController.instance.playerEvents.OnPlayerReceiveDamage += DamageTaken;
    }

    void ResetStats()
    {
        damageTaken = 0;
        enemiesKilled.Clear();
    }

    void DamageTaken(float damageTaken, float healthLeft)
    {
        this.damageTaken += damageTaken;
    }

    void OnEnemyDied(EnemyHealth enemy)
    {
        //enemiesKilled[enemy.id] += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deinit()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage -= DamageTaken;
        EventController.instance.enemyEvents.OnEnemyDied -= OnEnemyDied;
        ResetStats();
    }

    [System.Serializable]
    public class RoundStatisticsData
    {
        public RoundStatisticsData(float damageTaken, List<int> enemiesKilled)
        {
            this.damageTaken = damageTaken;
            this.enemiesKilled = enemiesKilled;
        }

        public float damageTaken;
        public List<int> enemiesKilled;
    }
}
