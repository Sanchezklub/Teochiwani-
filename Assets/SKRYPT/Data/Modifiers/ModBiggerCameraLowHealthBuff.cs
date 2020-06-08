using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

[CreateAssetMenu(fileName = "BiggerCameraLowHealthBuff", menuName = "Modifiers/BiggerCameraLowHealthBuff")]
public class ModBiggerCameraLowHealthBuff : BaseModifier
{
    [SerializeField]
    private float maxCameraPercentage;
    public float MaxDamagePercentage => maxCameraPercentage;

    private float initialSize;
    private CinemachineVirtualCamera camera;
    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        camera = Camera.main.GetComponent<CinemachineBrain>()?.ActiveVirtualCamera as CinemachineVirtualCamera;
        initialSize = camera.m_Lens.OrthographicSize;
        AssignEvents();
        OnPlayerReceiveDamage(0, GameController.instance.DataStorage.PlayerInfo.currenthealth);
    }

    public void AssignEvents()
    {
        EventController.instance.playerEvents.OnPlayerReceiveDamage += OnPlayerReceiveDamage;
        EventController.instance.playerEvents.OnPlayerDie += PlayerDied;
    }

    public void OnPlayerReceiveDamage(float damage, float healthLeft)
    {
        var maxhealth = GameController.instance.DataStorage.PlayerInfo.maxhealth;
        var value = (1f - Mathf.InverseLerp(0f, maxhealth, healthLeft)) * (maxCameraPercentage / 100);
        camera.m_Lens.OrthographicSize = initialSize + initialSize * value;
    }

    public void PlayerDied()
    {
        Deinit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Deinit()
    {
        camera.m_Lens.OrthographicSize = initialSize;
        EventController.instance.playerEvents.OnPlayerReceiveDamage -= OnPlayerReceiveDamage;
        EventController.instance.playerEvents.OnPlayerDie -= PlayerDied;

        base.Deinit();
    }
}
