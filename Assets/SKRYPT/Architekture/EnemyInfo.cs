using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "Enemy", order = 0)]
public class EnemyInfo : ScriptableObject
{
    public Enemy enemyPrefab;

    [SerializeField]
    private int health;
    public int Healt => health;

    public int strenght;
    public float speed;
}
