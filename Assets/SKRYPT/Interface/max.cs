using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class max : MonoBehaviour
{
    public float HorizontalSpeed = 1 ;
    public float MaxHorizontalPosition = 20000 ;
    public float MinHorizontalPosition = -20000 ;
     bool moveRight=true;
    private RectTransform rectTransform;
 
 void Start ()
 {
     rectTransform = GetComponent<RectTransform>();
 }
 
 void Update ()
 {
    
     Vector2 position = rectTransform.anchoredPosition;
 
    /* position.x += HorizontalSpeed * Time.unscaledDeltaTime;
     
     if( position.x > MaxHorizontalPosition )
         position.x = MinHorizontalPosition ;
    
     rectTransform.anchoredPosition = position;
 
    */
     
    if( moveRight  && MaxHorizontalPosition< position.x )
      moveRight=false;
    else if  ( position.x< MinHorizontalPosition && moveRight==false)
    moveRight=true;
     
     if ( moveRight == true)
     {
          position.x += HorizontalSpeed * Time.unscaledDeltaTime;
     }
     else 
     {
        position.x -= HorizontalSpeed * Time.unscaledDeltaTime;
     }
      rectTransform.anchoredPosition = position;
}
}
