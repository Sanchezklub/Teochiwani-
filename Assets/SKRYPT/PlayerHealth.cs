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
        GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        healthBar.value = GameController.instance.DataStorage.PlayerInfo.maxhealth;
    }

    void Update()
    {
        healthBar.value = GameController.instance.DataStorage.PlayerInfo.currenthealth;
    }

    public override void TakeDamage(float damage)
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth -= damage;
        if (FloatingText == true)
        {
            ShowFloatingText(damage);
        }
        if (GameController.instance.DataStorage.PlayerInfo.currenthealth <= 0)
        {
            Die();

        }

    }

    protected override void Die()
    {
        Vector2 newPos = new Vector2(StartingPosition.x, StartingPosition.y);
        GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        transform.position = newPos;
    }

}
