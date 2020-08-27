using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiguelEvents : MonoBehaviour
{
    private FalseGodsBrain brain;

    private void Start()
    {
        brain = GetComponentInParent<FalseGodsBrain>();
    }
    public void StartDying()
    {
        brain.StartDying();
    }

    public void GetDestroyed()
    {
        GameObject.Destroy(this.transform.parent.gameObject);
    }
}
