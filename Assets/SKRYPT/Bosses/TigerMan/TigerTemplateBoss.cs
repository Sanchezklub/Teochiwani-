using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerTemplateBoss : MonoBehaviour
{

    public Rigidbody2D tigerRb;

    public float delay;
    public float speed;

    private bool attack = false;

    private float startTime;

    private TigerBoss boss;

    public void Init(TigerBoss boss)
    {
        var move = (boss.transform.position - transform.position).normalized;
        if (move.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        this.boss = boss;
        startTime = Time.time;
        attack = true;
    }

    private void Update()
    {
        if (!attack)
            return;


        if(startTime + delay < Time.time)
        {
            transform.position = Vector3.MoveTowards(transform.position, boss.transform.position, speed);
            if(Vector2.Distance(transform.position, boss.transform.position) < .5f)
            {
                transform.parent = boss.HandPosition.transform;
                transform.localPosition = Vector3.zero;
                attack = false;
                boss.TigerAttack(this);
            }
        }
    }
}
