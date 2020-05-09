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
        public UnityAction<float, float, GameObject> OnPlayerReceiveDamageWithAttacker;
        public void CallOnPlayerReceiveDamage(float damage, float healthLeft, GameObject attacker = null)
        {
            OnPlayerReceiveDamageBasic?.Invoke();
            OnPlayerReceiveDamage?.Invoke(damage, healthLeft);
            OnPlayerReceiveDamageWithAttacker?.Invoke(damage, healthLeft, attacker);
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
        public UnityAction OnCocoaPickupBasic;
        public UnityAction<int> OnCocoaPickup;
        public void CallOnCocoaPickup(int amount)
        {
            OnCocoaPickupBasic?.Invoke();
            OnCocoaPickup?.Invoke(amount);
        }
        
        public UnityAction OnBloodPickupBasic;
        public UnityAction<int> OnBloodPickup;
        public void CallOnBloodPickup(int amount)
        {
            OnBloodPickupBasic?.Invoke();
            OnBloodPickup?.Invoke(amount);
        }
    }


}

