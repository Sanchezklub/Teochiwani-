using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthController : MonoBehaviour
{

    [SerializeField]
    GameObject CutHealth;
    Slider HealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage += OnDamageTaken;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDamageTaken(float DamageTaken, float HealthLeft)
    {
        Debug.Log("HealthController :: OnDamageTakenCalled");
        GameObject DamagedBar = Instantiate(CutHealth, transform);
        RectTransform DamagedBarRect = DamagedBar.GetComponent<RectTransform>();
        //DamagedBarRect.sizeDelta = new Vector2((DamageTaken / GameController.instance.DataStorage.PlayerInfo.maxhealth) * 250, DamagedBarRect.sizeDelta.y);
        DamagedBarRect.anchoredPosition = new Vector2(Mathf.Lerp(-200, 50, DamageTaken / GameController.instance.DataStorage.PlayerInfo.maxhealth), DamagedBarRect.anchoredPosition.y);
        DamagedBar.SetActive(true);
    }
}
