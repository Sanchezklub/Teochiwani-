using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{

    //public static ScreenShake instance; na razie nie musimy singletona;

    [SerializeField] CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin noise;
    private void Start()
    {
        noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        EventController.instance.playerEvents.OnPlayerReceiveDamage += OnPlayerReceiveDamage;
    }

    public IEnumerator ShakeScreen(float magnitude, float time)
    {
        Debug.Log("ShakeStarted");
        noise.m_AmplitudeGain = magnitude;
        yield return new WaitForSeconds(time);
        noise.m_AmplitudeGain = 0;
    }
    void OnPlayerReceiveDamage(float damage, float healthleft)
    {
        if (damage < 25)
        {
            StartCoroutine(ShakeScreen(1, .4f));
        }
        else
        {
            StartCoroutine(ShakeScreen(1.6f, .5f));
        }
    }

    private void OnApplicationQuit()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage -= OnPlayerReceiveDamage;
    }
}
