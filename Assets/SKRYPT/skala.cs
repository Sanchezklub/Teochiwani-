using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skala : MonoBehaviour
{
    [SerializeField]
    private int Health = 50;
    [SerializeField]
    int currentHealth;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = Health;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void TakeDamage(int attackdamage)
    {
        currentHealth -= attackdamage;

    }
    private void Update()
    {
        if (currentHealth <= 25)
        {
            anim.SetTrigger("damage1");
        }
        if (currentHealth < 0)
        {
            anim.SetTrigger("death");
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
