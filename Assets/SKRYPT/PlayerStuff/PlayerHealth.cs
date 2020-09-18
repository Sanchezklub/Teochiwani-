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
    [SerializeField] private GameObject YouDiedScreen;
    public Vector2 StartingPosition;
    [SerializeField] private LevelDeleter deleter;
    private SplashController splash;
    private bool CanBeHit = true;
    [SerializeField] float InvincibleTime;

    protected override void Start()
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        healthBar.value = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        PlayerAnimator = GetComponent<Animator>();
        //splash = GetComponent<SplashController>();
    }

    void Update()
    {
        healthBar.value = GameController.instance.DataStorage.PlayerInfo.currenthealth;
        if ( GameController.instance.DataStorage.PlayerInfo.currenthealth > GameController.instance.DataStorage.PlayerInfo.maxhealth)
        {
            
            GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        }
    }

    public override void TakeDamage(float damage, GameObject attacker = null)
    {
        if (CanBeHit)
        {
            Debug.LogFormat("damage taken was {0}", damage);
            GameController.instance.DataStorage.PlayerInfo.currenthealth -= damage;

            //MeteorMod
            EventController.instance.playerEvents.CallOnPlayerReceiveDamage(damage, GameController.instance.DataStorage.PlayerInfo.currenthealth, attacker);
            if (FloatingText == true)
            {
                ShowFloatingText(damage);
            }

            splashController.MakeSplat();

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
            StartCoroutine("Invincibility");
        }


    }
    public override void Heal(float heal)
    {
        
    }
    protected override void Die()
    {
        PlayerAnimator.SetTrigger("Die");
        //File.Delete( Application.persistentDataPath+"/player.fun");

        //MainMenu.SetActive(true);

        /*Vector2 newPos = new Vector2(StartingPosition.x, StartingPosition.y);
        GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        transform.position = newPos;
        Destroy(gameObject, 2);*/
    }
    void FinishDie()
    {
        YouDiedScreen.SetActive(true);
    }

    public void HurtSound()
    {
        int rand = Random.Range(0, 2);
        if (rand == 1)
        {
            AudioManager.instance.Play("Hurt");
        }
        else
        {
            AudioManager.instance.Play("Hurt 2");
        }
    }

    public IEnumerator Invincibility()
    {
        CanBeHit = false;
        yield return new WaitForSeconds(InvincibleTime);
        CanBeHit = true;

    }
}
