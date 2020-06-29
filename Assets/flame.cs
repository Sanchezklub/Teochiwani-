using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flame : MonoBehaviour

{
    public float dmg;
    public float range;
    public LayerMask enemyLayers;
    GameObject Smok;
              
    void Start()
    {
        Smok = GameObject.FindGameObjectWithTag("Smok");
        dmg = Smok.GetComponent<DragonBrain>().dmg;
    }

    void Update()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, range, enemyLayers);
        foreach (Collider2D Player in hitEnemies)
        {
            Player.GetComponent<Health>()?.TakeDamage(dmg);
        }
    }
}
