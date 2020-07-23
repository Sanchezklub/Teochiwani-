using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin noise;
    private void Start()
    {
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public IEnumerator ShakeScreen(float magnitude, float time)
    {
        Debug.Log("ShakeStarted");
        noise.m_AmplitudeGain = magnitude;
        yield return new WaitForSeconds(time);
        noise.m_AmplitudeGain = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(ShakeScreen(1.5f, 1f));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(ShakeScreen(0.4f, 3));
        }
    }

}
