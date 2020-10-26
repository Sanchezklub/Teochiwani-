using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailerKaplan : MonoBehaviour
{
    public float PoIluSekundachAnimacje;
    public Animator anim;
    void Start()
    {
       StartCoroutine (StartAnimacji());
    }

    IEnumerator StartAnimacji()
    {
        
        yield return new WaitForSeconds(PoIluSekundachAnimacje);
        anim.SetBool("After8sekund", true);
        
    }
}
