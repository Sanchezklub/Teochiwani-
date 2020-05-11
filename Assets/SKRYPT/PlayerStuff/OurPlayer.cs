using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurPlayer : MonoBehaviour
{
    public static OurPlayer instance;

    private void Start()
    {
        instance = this;
    }

    public void TakeDamage(float dmg)
    {
        Debug.Log(dmg + " Damage taken");
    }
}
