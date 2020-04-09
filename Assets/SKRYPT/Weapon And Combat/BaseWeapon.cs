using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public int CocaoPrice;
    public int BloodPrice;
    public GameObject FloatingTextPrefab;
    public GameObject Handle;
    public string AnimationType;
    public abstract void Attack(PlayerCombat controller);
    public abstract void PickupWepaon();
    public abstract void DropWeapon();
    public virtual void ShowFloatingText(string flavourtext)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = flavourtext;


    }
}
