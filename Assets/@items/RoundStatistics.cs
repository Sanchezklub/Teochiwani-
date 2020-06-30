using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStatistics : MonoBehaviour
{
    // Start is called before the first frame update
    public static RoundStatistics instance;
    
    public float damageTaken;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ResetStats();
        EventController.instance.playerEvents.OnPlayerReceiveDamage += DamageTaken;
    }

    void ResetStats()
    {
        damageTaken = 0;
    }

    void DamageTaken(float damageTaken, float healthLeft)
    {
        this.damageTaken += damageTaken;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deinit()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage -= DamageTaken;
        ResetStats();
    }
}
