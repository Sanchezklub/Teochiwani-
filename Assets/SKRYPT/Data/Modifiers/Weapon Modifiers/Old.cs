using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "Old", menuName = "Modifiers/Old")]
public class Old : BaseModifier
{
    [SerializeField] private float DamageDiff;
    public override void Init(UnityAction<BaseModifier> OnCompletedCallback = null)
    {
        base.Init(OnCompletedCallback);
        
    }

    void PlayerDied()
    {
        Deinit();
    }

    public override void Deinit()
    {
        
        base.Deinit();
    }
}
