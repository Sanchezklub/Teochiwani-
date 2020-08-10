using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwucieciwka : BaseWeapon
{
    Vector2 direction; 
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float LaunchForce;
    public void Update()
    {
        Vector2 bowPosition = Handle.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        Handle.transform.right=direction;  
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
        GameObject newArrow = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation*= Quaternion.Euler(0, 0, -10));
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        GameObject newArrow1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation*= Quaternion.Euler(0, 0, 10));
        newArrow1.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
    }
}
