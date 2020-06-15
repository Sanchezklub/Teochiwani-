using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkolopendraHealth : EnemyHealth
{
    private Queue<SpriteRenderer> SpriteQueue = new Queue<SpriteRenderer>();
    [SerializeField] private List<SpriteRenderer> sprites;

    protected override void Start()
    {
        base.Start();
        foreach (SpriteRenderer sprite in sprites)
        {
            SpriteQueue.Enqueue(sprite);
        }
    }


    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        currentHealth -= 1;
        if (SpriteQueue.Count > 0)
        {
            SpriteQueue.Peek().enabled = false;
            SpriteQueue.Dequeue();
        }
        if (currentHealth <= 0)
        {
            Die();
        }

    }
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
