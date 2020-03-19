using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : Health
{
    public Slider healthBar;
    public Vector2 StartingPosition;

    protected override void Start()
    {
        base.Start();
        healthBar.value = MaxHealth;
    }

    void Update()
    {
        healthBar.value = currentHealth;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    protected override void Die()
    {
        Vector2 newPos = new Vector2(StartingPosition.x, StartingPosition.y);
        currentHealth = MaxHealth;
        transform.position = newPos;
    }

}
