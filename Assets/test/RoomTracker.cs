using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTracker : MonoBehaviour
{
    public List<RoomId> rooms = new List<RoomId>();

    // Start is called before the first frame update
    void Start()
    {
        EventController.instance.levelEvents.OnRoomGenerated += OnRoomGenerated;
    }

    void OnRoomGenerated(RoomId id)
    {
        rooms.Add(id);
    }

    private void OnApplicationQuit()
    {
        if(EventController.instance != null)
        {
            EventController.instance.levelEvents.OnRoomGenerated -= OnRoomGenerated;
        }
    }
}
