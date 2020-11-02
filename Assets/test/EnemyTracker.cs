using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyTracker : MonoBehaviour
{
    public List<EnemyHealth> enemies = new List<EnemyHealth>();

    public void Start()
    {
        EventController.instance.enemyEvents.OnEnemyAppear += OnNewEnemy;
        EventController.instance.enemyEvents.OnEnemyDied += OnEnemyDie;
        EventController.instance.enemyEvents.OnEnemyDestroyed += OnEnemyDie;
    }

    public void OnNewEnemy(EnemyHealth newEnemy)
    {
        //Debug.Log("NewEnemy");
        enemies.Add(newEnemy);
    }

    public void OnEnemyDie(EnemyHealth enemy)
    {
        enemies.Remove(enemy);
    }

    private void OnApplicationQuit()
    {
        EventController.instance.enemyEvents.OnEnemyAppear -= OnNewEnemy;
        EventController.instance.enemyEvents.OnEnemyDied -= OnEnemyDie;
        EventController.instance.enemyEvents.OnEnemyDestroyed -= OnEnemyDie;
    }

}
