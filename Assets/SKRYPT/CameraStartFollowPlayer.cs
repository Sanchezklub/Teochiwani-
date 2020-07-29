using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraStartFollowPlayer : MonoBehaviour
{
    private void Start()
    {
        Invoke("FollowPlayer", 0.1f);
    }

    void FollowPlayer()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player")?.transform;
        CinemachineVirtualCamera cam = GetComponent<CinemachineVirtualCamera>();
        cam.m_Follow = player;
    }
}
