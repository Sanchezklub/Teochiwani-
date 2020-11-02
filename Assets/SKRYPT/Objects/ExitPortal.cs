using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{

    private bool called = false;

    [SerializeField] private BoxCollider2D coll;
    [SerializeField] private GameObject particles;
    private void Start()
    {
        EventController.instance.enemyEvents.OnBossDiedBasic += Activate;
    }

    void Activate()
    {
        coll.enabled = true;
        particles.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !called)
        {
            called = true;
            coll.enabled = false;
            EventController.instance.levelEvents.CallOnLevelEnded();
        }
    }
}
