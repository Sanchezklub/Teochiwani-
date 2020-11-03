using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private DataStorage dataStorage;
    public DataStorage DataStorage => dataStorage;

    [SerializeField]
    private ReturnPlayerDataToDefaults defaultPlayerData;
    public ReturnPlayerDataToDefaults DefaultPlayerData => defaultPlayerData;



    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage += dataStorage.PlayerInfo.CallOnGetHurtAction;
    }
    private void Update()
    {


    }
}
