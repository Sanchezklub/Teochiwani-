using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecisiceBow : BaseWeapon
{
    Vector2 direction; 
    public Transform firePoint;
    
    public GameObject bulletPrefab;
    public GameObject point;
    GameObject[] points;
    
    public int numberOfPoints;
    public float LaunchForce;
    public float spaceBetweenPoints;


    //public void Start()
   // {
        /*
       points = new GameObject[numberOfPoints];
        for (int i=0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, firePoint.position, Quaternion.identity);
        }*/
    //}
    public void Update()
    {
        if ( PickUped)
        {
        Vector2 bowPosition = Handle.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        Handle.transform.right=direction;
        }  
     /*   if ( Handle.transform.rotation.z <= 15 || Handle.transform.rotation.z >= -15 )
        {
            Handle.transform.right=direction;  
        }
        else
        {
 
        }*/
        

    /*    for (int i=0; i < numberOfPoints; i++)
        {
            points[i].transform.position = Pointposition(i * spaceBetweenPoints);
   
        }*/
    }
    Vector2 Pointposition(float t)
    {
        //float x = LaunchForce * t;
        //float y = transform.y + 
        Vector2 position=(Vector2)firePoint.position + (direction.normalized * 70 * t)+ 0.5f * Physics2D.gravity * (t *t);
        return position;
    }
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Bow :: Attack() - Player attacked with bow");
        GameObject newArrow = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
    }

    



   /* public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    public static Vector2 Parabola(Vector2 start, Vector2 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector2.Lerp(start, end, t);

        return new Vector2(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t));
    }*/

}