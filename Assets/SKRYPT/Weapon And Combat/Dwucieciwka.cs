using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwucieciwka : BaseWeapon
{
    Vector2 direction; 
    public GameObject bulletPrefab;
    public float LaunchForce;
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
        Vector2 position=(Vector2)AttackPoint.position + (direction.normalized * 70 * t)+ 0.5f * Physics2D.gravity * (t *t);
        return position;
    }
    public override void Attack(PlayerCombat controller)
    {
        Debug.Log("Bow :: Attack() - Player attacked with bow");
        GameObject newArrow = Instantiate(bulletPrefab, new Vector3(AttackPoint.position.x, AttackPoint.position.y-1, AttackPoint.position.z ), AttackPoint.rotation);
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        newArrow.GetComponent<Strzala>().weapon = this;
        GameObject newArrow1 = Instantiate(bulletPrefab, new Vector3(AttackPoint.position.x, AttackPoint.position.y+1, AttackPoint.position.z ), AttackPoint.rotation);
        newArrow1.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce;
        newArrow1.GetComponent<Strzala>().weapon = this;
        AudioManager.instance.Play("Bow");

    }
}
