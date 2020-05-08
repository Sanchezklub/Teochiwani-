using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventController : MonoBehaviour
{
    public static EventController instance;

    //private PlayerEvents player { get; } = new PlayerEvents();
    public PlayerEvents playerEvents;
    private void Awake()
    {
        instance = this;
        playerEvents = new PlayerEvents();
    }

    public class PlayerEvents
    {
        public UnityAction OnPlayerJumpedBasic;
        public UnityAction<CharacterController2D> OnPlayerJumped;

        public void CallOnPlayerJumped(CharacterController2D character)
        {
            OnPlayerJumpedBasic?.Invoke();
            OnPlayerJumped?.Invoke(character);
        }

        public UnityAction OnPlayerUseWeaponBasic;
        public UnityAction<BaseWeapon> OnPlayerUseWeapon;
        public void CallOnPlayerUseWeapon(BaseWeapon weapon)
        {
            OnPlayerUseWeaponBasic?.Invoke();
            OnPlayerUseWeapon?.Invoke(weapon);
        }
        public UnityAction OnPlayerDealDamageBasic;
        public UnityAction<float> OnPlayerDealDamage;
        public void CallOnPlayerDealDamage(float damage)
        {
            OnPlayerDealDamageBasic?.Invoke();
            OnPlayerDealDamage?.Invoke(damage);
        }

        public UnityAction OnPlayerRecieveDamageBasic;
        public UnityAction<float, float> OnPlayerRecieveDamage;

        public void CallOnPlayerRecieveDamage(float damage, float healthleft)
        {
            OnPlayerRecieveDamageBasic?.Invoke();
            OnPlayerRecieveDamage?.Invoke(damage, healthleft);
        }

    }
}
