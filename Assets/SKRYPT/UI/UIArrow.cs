using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrow : MonoBehaviour
{
    //public Transform portalTransform;
    [SerializeField]Vector3 Vector;
    [SerializeField] float DistanceFromPlayer;
    [SerializeField] float angle;
    [SerializeField] SpriteRenderer SR;
    [SerializeField] float FadingDistance;
    //Quaternion facing;
    private void Start()
    {
        //facing = transform.rotation;
    }

    private void Update()
    {
        Vector = Vector3.Normalize(new Vector2(GameController.instance.DataStorage.PlayerInfo.portalPosition.x - transform.position.x, GameController.instance.DataStorage.PlayerInfo.portalPosition.y - transform.position.y));
        transform.position = GameController.instance.DataStorage.PlayerInfo.playerPosition + (Vector * DistanceFromPlayer);
        //var rotation = Quaternion.LookRotation(Vector);
        //rotation *= facing;
        //transform.rotation = rotation;
        if ( Vector2.Distance( GameController.instance.DataStorage.PlayerInfo.playerPosition,GameController.instance.DataStorage.PlayerInfo.portalPosition ) < FadingDistance)
        {
            SR.enabled=false;
        }
        else
        {
            SR.enabled=true;
        }
        if (Vector.x >= 0)
        {
            angle = Vector3.Angle(new Vector2(0, 1), Vector);
        }
        else
        {
            angle = 360 - Vector3.Angle(new Vector2(0, 1), Vector);
        }
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        float dist = Vector3.Distance(GameController.instance.DataStorage.PlayerInfo.playerPosition, GameController.instance.DataStorage.PlayerInfo.portalPosition);
        float lerpedVal = Mathf.InverseLerp(2000, 50, dist);
        float finalVal = Mathf.Lerp(6, 15, lerpedVal);
        transform.localScale = new Vector3(finalVal, finalVal, 1);
    }
}
