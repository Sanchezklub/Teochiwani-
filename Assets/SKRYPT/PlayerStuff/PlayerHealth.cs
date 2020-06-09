using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    private Animator PlayerAnimator;
    public Slider healthBar;
    public GameObject MainMenu;
    public Vector2 StartingPosition;
    [SerializeField] private LevelDeleter deleter;

    protected override void Start()
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        healthBar.value = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        healthBar.value = GameController.instance.DataStorage.PlayerInfo.currenthealth;
    }

    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth -= damage;

        //MeteorMod
        EventController.instance.playerEvents.CallOnPlayerReceiveDamage(damage, GameController.instance.DataStorage.PlayerInfo.currenthealth, attacker);
        if (FloatingText == true)
        {
            ShowFloatingText(damage);
        }
        if (GameController.instance.DataStorage.PlayerInfo.currenthealth <= 0)
        {
            //MeteorMod
            EventController.instance.playerEvents.CallOnPlayerDie();
            Die();
        }
        else
        {
            PlayerAnimator.SetTrigger("isDamaged");
        }

    }

    protected override void Die()
    {
        PlayerAnimator.SetTrigger("Die");
        File.Delete( Application.persistentDataPath+"/player.fun");
        deleter.Delete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //MainMenu.SetActive(true);

        /*Vector2 newPos = new Vector2(StartingPosition.x, StartingPosition.y);
        GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        transform.position = newPos;
        Destroy(gameObject, 2);*/
    }

}
