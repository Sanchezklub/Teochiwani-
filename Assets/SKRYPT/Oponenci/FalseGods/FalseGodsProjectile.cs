using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGodsProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float damage;
    [SerializeField] private float lifetime;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer MyRenderer;
    void Start()
    {
        int rand = Random.Range(0, sprites.Length);
        MyRenderer.sprite = sprites[rand];  
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>()?.TakeDamage(damage);
        }
    }

}
