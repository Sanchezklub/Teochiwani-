using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public static EventController instance;

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

        public UnityAction OnPlayerReceiveDamageBasic;
        public UnityAction<float, float> OnPlayerReceiveDamage;
        public void CallOnPlayerReceiveDamage(float damage, float healthLeft)
        {
            OnPlayerReceiveDamageBasic?.Invoke();
            OnPlayerReceiveDamage?.Invoke(damage, healthLeft);
        }

        public UnityAction OnPlayerDie;
        public void CallOnPlayerDie()
        {
            OnPlayerDie?.Invoke();
        }

        public UnityAction<BaseItem> OnItemPickup;
        public void CallOnItemPickup(BaseItem item)
        {
            OnItemPickup?.Invoke(item);
        }
    }


}

