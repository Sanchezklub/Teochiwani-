using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skala : BaseBreakable
{
    public GameObject Particle;
    public Sprite mysprite1;
    public Sprite mysprite2;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Instantiate(this.Particle, this.transform.position, Quaternion.identity);
        if (CurrentHealth >= 40 && CurrentHealth <= 100)
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite1;
        }
        else if (CurrentHealth > 0 && CurrentHealth < 39)
        {
            this.GetComponent<SpriteRenderer>().sprite = mysprite2;
        }

    }
}
