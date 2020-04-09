using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kupiec : MonoBehaviour
{
    public GameObject stragan;
public GameObject[] bronie;

public void Start()
{
Instantiate(stragan, new Vector3(transform.position.x+10,transform.position.y,transform.position.z), Quaternion.identity );
Instantiate(stragan, new Vector3(transform.position.x-10,transform.position.y,transform.position.z), Quaternion.identity );
int rand = Random.Range(0, bronie.Length);
Instantiate(bronie[rand], transform.position, Quaternion.identity );
}
}
