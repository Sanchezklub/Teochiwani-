using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
