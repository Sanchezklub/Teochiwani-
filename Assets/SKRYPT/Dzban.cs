using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dzban : BaseEnemy
{
    [SerializeField]
    private int minimumCount = 1;
    [SerializeField]
    private int maximumCount = 3;
    [SerializeField]
    private GameObject prefab = null;
    [SerializeField] UnityEngine.Object destrutableRef;

    public int MinimumCount
    {
        get { return this.minimumCount; }
        set { this.minimumCount = value; }
    }
    public int MaximumCount
    {
        get { return this.maximumCount; }
        set { this.maximumCount = value; }
    }
    public GameObject Prefab
    {
        get { return this.prefab; }
        set { this.prefab = value; }
    }

    public void Spawn()
    {
        // Randomly pick the count of prefabs to spawn.
        int count = Random.Range(this.MinimumCount, this.MaximumCount);
        // Spawn them!
        for (int i = 0; i < count; ++i)
        {
            Instantiate(this.prefab, this.transform.position, Quaternion.identity);
        }
    }

    private void ExplodeThisGameObject()
    {
        GameObject destrutable = (GameObject)Instantiate(destrutableRef);
        destrutable.transform.position = transform.position;
        Destroy(gameObject);
    }

    public override void Die()
    {
        var coinRewarder = this.GetComponent<Dzban>();
        if (coinRewarder != null)
        {
            coinRewarder.Spawn();
        }
        ExplodeThisGameObject();
    }

}
