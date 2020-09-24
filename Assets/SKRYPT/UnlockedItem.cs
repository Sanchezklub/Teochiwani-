using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UnlockedItem : MonoBehaviour
{

    public GameObject ItemDictionary;

    public GameObject UnlockBackground;
    public GameObject UnlockText;

    public GameObject UnlockItemSprite;
    

    
   // public int id;
    
    
    [ContextMenu("Show Item")]
    public void ShowItem(int id)
    {
        StartCoroutine (TurnOFF());
        UnlockBackground.SetActive(true);
        var go = ItemDictionary.GetComponentInChildren<ID_dictionary>().GetItemObjects(id);
        UnlockItemSprite.GetComponent<Image>().sprite = go.GetComponentInChildren<SpriteRenderer>().sprite;
        UnlockText.GetComponent<TextMeshProUGUI>().text= go.GetComponentInChildren<BaseItem>().itemName;

    }

    
    IEnumerator TurnOFF()
    {
        
        yield return new WaitForSeconds(3);
        UnlockBackground.SetActive(false);
    }
}
