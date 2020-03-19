using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkalaHealth : Health
{
    public GameObject Particle;
    public Sprite mysprite1;
    public Sprite mysprite2;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Instantiate(this.Particle, this.transform.position, Quaternion.identity);
        if (currentHealth >= 40 && currentHealth <= 100)
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite1;
        }
        else if (currentHealth > 0 && currentHealth < 39)
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite2;
        }

    }

    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }

}
