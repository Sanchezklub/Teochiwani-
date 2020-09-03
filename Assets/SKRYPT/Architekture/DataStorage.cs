using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStorage : MonoBehaviour
{
    [SerializeField]
    private PlayerInformation playerInfo;
    public PlayerInformation PlayerInfo => playerInfo;
    
    [SerializeField]
    private PlayerInformation evilPlayerInfo;
    public PlayerInformation EvilPlayerInfo => evilPlayerInfo;
}
