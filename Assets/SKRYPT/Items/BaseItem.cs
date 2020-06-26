using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public abstract class ItemConditioner
{
    public bool itemUnlocked;
    public BaseCondition condition;
}

public abstract class BaseItem : MonoBehaviour
{
    public BaseModifier[] modifiers;
    [SerializeField] public TextMeshProUGUI UIWeaponName;
    [SerializeField] public TextMeshProUGUI UIFlavorText;
    [SerializeField] private string flavourtext;
    [SerializeField] private string itemName;
    public int id;
    public GameObject FloatingTextPrefab;

    [SerializeField]
    private ItemConditioner conditioner;
    public ItemConditioner Conditioner => conditioner;

     private void Start()
    {
        //UIFlavourText = Find("FlavourText");
        EventController.instance.itemEvents.CallOnItemAppear(this);
        UIFlavorText = GameObject.FindGameObjectWithTag("FlavorText")?.GetComponentInChildren<TextMeshProUGUI>(true);
        UIWeaponName = GameObject.FindGameObjectWithTag("WeaponName")?.GetComponentInChildren<TextMeshProUGUI>(true);
    }

    public virtual void PickupItem()
    {
        //MeteorMod
        EventController.instance.playerEvents.OnItemPickup(this);
        GameController.instance.DataStorage.PlayerInfo.ItemIDs.Add(id);
        ShowFloatingText();
    }

    /*
    public virtual void ShowFloatingText(string flavourtext)
    {
        var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity);
        go.GetComponent<TextMesh>().text = flavourtext;


    }
    */

    /*
    public virtual void OnTriggerEnter2D(Collider2D coll2)
    {
        if (coll2.tag == "Player")
        {
            ShowFloatingText(itemName);
            //Destroy(this, 5);
        }
    }*/
    public virtual void ShowFloatingText()
    {
        //var go = Instantiate(FloatingTextPrefab, transform.position, Quaternion.identity, transform);
        //go.GetComponent<TextMesh>().text = flavourtext;
        if (UIFlavorText != null)
        {
            UIFlavorText.enabled = true;
            UIFlavorText.SetText(flavourtext);
            UIFlavorText.GetComponent<Animator>()?.SetTrigger("Enabled");
        }
        if (UIWeaponName != null)
        {
            UIWeaponName.enabled = true;
            UIWeaponName.SetText(itemName);
            UIWeaponName.GetComponent<Animator>()?.SetTrigger("Enabled");
        }

    }

    public virtual void BuffJumpHeight(int JumpHeigt)
    {

    }
    public virtual void BuffAttackDamage(int Damage)
    {

    }
    public virtual void BuffHealth(int Health)
    {

    }

}
