using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podest : MonoBehaviour
{
   public BoxCollider2D collider;
   public LayerMask PlayerMask;
   public float Range=10f;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.S) )
        {
            Debug.Log("JD");
            collider.isTrigger = true;
            StartCoroutine(waiter());
   
        }
    }
    IEnumerator waiter()
    {
        //Wait for 2 seconds
        yield return new WaitForSeconds(1);
        collider.isTrigger = false;
    }
}
