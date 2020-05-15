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
    [SerializeField] public TextMeshProUGUI UIFlavourText;
    public string Name;
    public int id;
    public string FlavourText;
    private void Start()
    {
       
        //UIFlavourText = Find("FlavourText");
        EventController.instance.weaponEvents.CallOnWeaponAppear(this);
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
        UIFlavourText.SetText(FlavourText);
        UIFlavourText.enabled = true;
        UIFlavourText?.GetComponent<Animator>()?.SetTrigger("Enabled");
        UIWeaponName.SetText(Name);
        UIWeaponName.enabled = true;
        UIWeaponName?.GetComponent<Animator>()?.SetTrigger("Enabled");

    }
}
