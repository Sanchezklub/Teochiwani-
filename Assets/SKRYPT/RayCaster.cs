using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public ParticleSystem splatParticles;
    public GameObject splatPrefab;
    public Transform splatHolder;

    private void Start()
    {
        EventController.instance.enemyEvents.OnEnemyGetDamageBasic += CastRay;
    }




    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

        if(hit.collider != null)
        {
            GameObject splat = Instantiate(splatPrefab, hit.point, Quaternion.identity) as GameObject;
            splat.transform.SetParent(splatHolder, true);
            Splat splatScript = splat.GetComponent<Splat>();

            splatParticles.transform.position = hit.point;
            splatParticles.Play();

            if (hit.collider.gameObject.tag == "BG")
                splatScript.Inicialize(Splat.SplatLocation.Background);
            else
                splatScript.Inicialize(Splat.SplatLocation.Foreground);

        }

    }



}
