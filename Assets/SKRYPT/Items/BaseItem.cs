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
    public GameObject Handle;
    public BaseModifier[] modifiers;
    [SerializeField] public TextMeshProUGUI UIWeaponName;
    [SerializeField] public TextMeshProUGUI UIFlavorText;
    [SerializeField] public string flavourtext;
    [SerializeField] public string itemName;
    [SerializeField] public int id;
    [SerializeField] public int ModId;
    [SerializeField] public int CocaoPrice;
    [SerializeField] public int BloodPrice;
    [SerializeField] public  Collider2D coll;
    public GameObject FloatingTextPrefab;
    [SerializeField]
    private ItemConditioner conditioner;
    public ItemConditioner Conditioner => conditioner;

     public virtual void Start()
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
        coll.enabled = false;
        Destroy(gameObject);
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
    public virtual void DropWeapon()
    {

        Handle.transform.parent = null;
        coll.enabled = true;
        Handle.transform.localEulerAngles = new Vector3(0,0,0);
    }

    public virtual void PickupWepaon()
    {
        coll.enabled = false;
        ShowFloatingText();
        gameObject.transform.localEulerAngles = new Vector3(0,0,0);
        EventController.instance.itemEvents.CallOnItemDied(this);
    }
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
}
