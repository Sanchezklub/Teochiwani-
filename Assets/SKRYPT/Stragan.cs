using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stragan : MonoBehaviour
{
    public GameObject[] sprzet;

int cena;
bool kakao1;
bool kakao2;
int playerKakao;
int playerBlood;
    public void Start()
{
    playerBlood = GameController.instance.DataStorage.PlayerInfo.blood;
    playerKakao = GameController.instance.DataStorage.PlayerInfo.cocoa;
}
}
