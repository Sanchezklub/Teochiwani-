using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DzbanHealth : Health
{
    [SerializeField]
    private int minimumCount = 1;
    [SerializeField]
    private int maximumCount = 3;
    [SerializeField]
    private GameObject[] Prefabs;
    private GameObject ChosenPrefab;
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

    public void Spawn()
    {
        // Randomly pick the count of prefabs to spawn.
        int count = Random.Range(this.MinimumCount, this.MaximumCount);
        // Spawn them!
        int rand = Random.Range(0, Prefabs.Length);
        ChosenPrefab = Prefabs[rand];
        for (int i = 0; i < count; ++i)
        {
            Instantiate(this.ChosenPrefab, this.transform.position, Quaternion.identity);
        }
    }

    private void ExplodeThisGameObject()
    {
        GameObject destrutable = (GameObject)Instantiate(destrutableRef);
        destrutable.transform.position = transform.position;
        Destroy(gameObject);
    }

    protected override void Die()
    {
        base.Die();
        AudioManager.instance.Play("VaseBreak");
        var coinRewarder = this.GetComponent<DzbanHealth>();
        if (coinRewarder != null)
        {
            coinRewarder.Spawn();
        }
        ExplodeThisGameObject();
    }
}
