using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIArrow : MonoBehaviour
{
    //public Transform portalTransform;
    [SerializeField]Vector3 Vector;
    [SerializeField] float DistanceFromPlayer;
    [SerializeField] float angle;
    //Quaternion facing;
    private void Start()
    {
        //facing = transform.rotation;
    }

    private void Update()
    {
        Vector = Vector3.Normalize(new Vector2(SaveSystem.Instance.levelGen.portalPosition.x - transform.position.x, SaveSystem.Instance.levelGen.portalPosition.y - transform.position.y));
        transform.position = GameController.instance.DataStorage.PlayerInfo.playerPosition + (Vector * DistanceFromPlayer);
        //var rotation = Quaternion.LookRotation(Vector);
        //rotation *= facing;
        //transform.rotation = rotation;
        
        if (Vector.x >= 0)
        {
            angle = Vector3.Angle(new Vector2(0, 1), Vector);
        }
        else
        {
            angle = 360 - Vector3.Angle(new Vector2(0, 1), Vector);
        }
        transform.rotation = Quaternion.Euler(0, 0, -angle);
        //float dist = Vector3.Distance()
    }
}
