using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    private Animator PlayerAnimator;
    public SimpleSlider healthBar;
    public GameObject MainMenu;
    [SerializeField] private GameObject YouDiedScreen;
    public Vector2 StartingPosition;
    [SerializeField] private LevelDeleter deleter;
    private SplashController splash;
    private bool CanBeHit = true;
    [SerializeField] private SpriteRenderer[] LimbSprites;
    [SerializeField] float InvincibleTime;

    protected override void Start()
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        //healthBar = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        PlayerAnimator = GetComponent<Animator>();
        //splash = GetComponent<SplashController>();
    }

    void Update()
    {
        healthBar.targetValue = GameController.instance.DataStorage.PlayerInfo.currenthealth/GameController.instance.DataStorage.PlayerInfo.maxhealth;
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

    [ContextMenu("Die")]
    protected override void Die()
    {
        PlayerAnimator.SetTrigger("Die");
        AudioManager.instance.OnDie();
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

    //public 
    public IEnumerator Invincibility()
    {
        CanBeHit = false;
        foreach(SpriteRenderer sprite in LimbSprites)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.7f);
        }
        yield return new WaitForSeconds(InvincibleTime);
        CanBeHit = true;
        foreach (SpriteRenderer sprite in LimbSprites)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
    }
}
