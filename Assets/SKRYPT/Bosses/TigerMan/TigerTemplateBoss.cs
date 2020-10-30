using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerTemplateBoss : MonoBehaviour
{

    public Rigidbody2D tigerRb;

    public float delay;
    public float speed;

    private bool attack = false;
    public bool velocityCheck;

    private float startTime;

    [SerializeField] private bool FacingRight;

    private TigerBoss boss;
    [SerializeField] private Animator anim;

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
        if ((transform.position.x > boss.transform.position.x && !FacingRight) || transform.position.x < boss.transform.position.x && FacingRight)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (velocityCheck)
        {
            if (Mathf.Abs(tigerRb.velocity.y) < .2f && Mathf.Abs(tigerRb.velocity.y) < .2f)
            {
                Instantiate(SaveSystem.Instance.Dictionary.EnemyObjects[9], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (!attack)
            return;


        if(startTime + delay < Time.time)
        {
            anim.SetTrigger("Attack");

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
    void Flip()
    {
        transform.Rotate(new Vector3(0,180,0));
        FacingRight = !FacingRight;
    }
}
