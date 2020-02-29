using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] float MaxHealth;
    [SerializeField] protected float CurrentHealth;
    public GameObject FloatingTextPrefab;
    public Animator animator;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        ShowFloatingText(damage);
        if (CurrentHealth <= 0)
        {
            Die();
        }


    }

    public virtual void ShowFloatingText(float damage)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = damage.ToString();
    }

    public virtual void Die()
    {
        Debug.Log("Dzban is dead");
        if (animator)
        { Destroy(gameObject, 3f); }
        else
        {
            Destroy(gameObject);
        }
    }
}



