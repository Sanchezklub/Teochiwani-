using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomId : MonoBehaviour
{
    public int roomNumber = 0;
    
    public int id;

    private void Start()
    {
        EventController.instance.levelEvents.CallOnRoomGenerated(this);
    }
}
