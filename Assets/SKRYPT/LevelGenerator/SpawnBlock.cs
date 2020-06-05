using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    public GameObject[] Jungle;
    public GameObject[] Gods;
    public GameObject[] Underground;
    public GameObject[] Sky;
    
    public GameObject SpawnPoint;

    public int Level=1;
    public int Magnitude;

    private void Start()
    {
        SpawnPoint = GameObject.FindGameObjectWithTag("LVLGEN");
        Magnitude = SpawnPoint.GetComponent<LevelGeneration>().MagnitudeL;       
        if (Level< 3)
        {
            if ( Magnitude==4)
            {
                int rand = Random.Range(0, Underground.Length);
                if (Underground.Length != 0)
                {
                    if(Underground[rand] != null)
                    {
                    GameObject obj = Instantiate(Underground[rand], transform.position, Quaternion.identity);
                    obj.transform.parent = this.gameObject.transform;
                    }
                }
            }
            if ( Magnitude == 3 || Magnitude == 2 )
            {
                int rand = Random.Range(0, Jungle.Length);
                if (Jungle.Length != 0)
                {
                    if(Jungle[rand] != null)
                    {
                    GameObject obj = Instantiate(Jungle[rand], transform.position, Quaternion.identity);
                    obj.transform.parent = this.gameObject.transform;
                    }
                }
            }
            if ( Magnitude == 1)
            {
                int rand = Random.Range(0, Sky.Length);
                if (Sky.Length != 0)
                {
                    if(Sky[rand] != null)
                    {
                    GameObject obj = Instantiate(Sky[rand], transform.position, Quaternion.identity);
                    obj.transform.parent = this.gameObject.transform;
                    }
                }
            }
        }   
        else  if ( Level >= 3)
        {
            if ( Magnitude == 1 || Magnitude == 2  )
            {
                int rand = Random.Range(0, Sky.Length);
                if (Sky.Length != 0)
                {
                    if(Sky[rand] != null)
                    {
                    GameObject obj = Instantiate(Sky[rand], transform.position, Quaternion.identity);
                    obj.transform.parent = this.gameObject.transform;
                    }
                }
            }
            if ( Magnitude == 3 || Magnitude == 4  )
            {
                int rand = Random.Range(0, Gods.Length);
                if (Gods.Length != 0)
                {
                    if(Gods[rand] != null)
                    {
                    GameObject obj = Instantiate(Gods[rand], transform.position, Quaternion.identity);
                    obj.transform.parent = this.gameObject.transform;
                    }
                }
            }
        
        
        
        }
    }
        
    
}
