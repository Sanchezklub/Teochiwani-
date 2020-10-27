using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBossCage : MonoBehaviour
{
    public TigerTemplateBoss tigerTemplate;

    public void OpenCage(TigerBoss boss)
    {
        TigerTemplateBoss tiger = Instantiate(tigerTemplate);
        tiger.gameObject.SetActive(true);
        tiger.Init(boss);
        tiger.transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
