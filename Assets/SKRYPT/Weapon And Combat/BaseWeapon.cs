using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public abstract class BaseWeapon : MonoBehaviour
{

    public GameObject FloatingTextPrefab;
    public GameObject Handle;
    [SerializeField] public TextMeshProUGUI UIWeaponName;
    [SerializeField] public TextMeshProUGUI UIFlavorText;
    public string Name;
    public int id;
    public string FlavorText;
    public void Awake()
    {
       
        //UIFlavourText = Find("FlavourText");
        EventController.instance.weaponEvents.CallOnWeaponAppear(this);
        GetUITexts();

    }

    public void GetUITexts()
    {
        UIFlavorText = GameObject.FindGameObjectWithTag("FlavorText")?.GetComponentInChildren<TextMeshProUGUI>(true);
        UIWeaponName = GameObject.FindGameObjectWithTag("WeaponName")?.GetComponentInChildren<TextMeshProUGUI>(true);
    }

    public enum AnimationType
    {
        IsAttackingVLight,
        IsAttackingLight,
        IsAttackingHeavy,
        IsAttackingVHeavy,
        IsAttackingRanged
    }
    public AnimationType AttackAnimationType;
    public abstract void Attack(PlayerCombat controller);
    public abstract void PickupWepaon();
    public abstract void DropWeapon();
    public virtual void ShowFloatingText(string flavourtext)
    {
        //var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        //go.GetComponent<TextMesh>().text = flavourtext;
        UIFlavorText.enabled = true;
        UIFlavorText.SetText(FlavorText);
        UIFlavorText?.GetComponent<Animator>()?.SetTrigger("Enabled");
        UIWeaponName.enabled = true;
        UIWeaponName.SetText(Name);
        UIWeaponName?.GetComponent<Animator>()?.SetTrigger("Enabled");

    }
}
