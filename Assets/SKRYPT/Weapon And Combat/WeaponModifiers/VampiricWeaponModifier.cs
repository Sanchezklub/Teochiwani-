using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Vampiric", menuName = "WeaponModifiers/Vampiric")]
public class VampiricWeaponModifier : BaseWeaponModifier
{
    void OnPlayerDealDamage(float damage)
    {
        GameController.instance.DataStorage.PlayerInfo.currenthealth+=damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
