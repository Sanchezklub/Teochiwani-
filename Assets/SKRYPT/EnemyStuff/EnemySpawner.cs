using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Enemies;
    private int rand;
    private void Start()
    {
        rand = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[rand], transform.position, Quaternion.identity);
    }
}
