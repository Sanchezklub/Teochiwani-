using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public static EventController instance;

    public PlayerEvents playerEvents;
    public EnemyEvents enemyEvents;
    public LevelEvents levelEvents;
    public EnviromentEvents enviromentEvents;
    private void Awake()
    {
        instance = this;
        playerEvents = new PlayerEvents();
        enemyEvents = new EnemyEvents();
        levelEvents = new LevelEvents();
        enviromentEvents = new EnviromentEvents();
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

        public UnityAction OnBloodLostBasic;
        public UnityAction<int> OnBloodLost;

        public void CallOnBloodLost(int amount)
        {
            OnBloodLostBasic?.Invoke();
            OnBloodLost?.Invoke(amount);
            Debug.Log("OnBloodLostCalled");
        }

        public UnityAction OnCocoaLostBasic;
        public UnityAction<int> OnCocoaLost;

        public void CallOnCocoaLost(int amount)
        {
            OnCocoaLostBasic?.Invoke();
            OnCocoaLost?.Invoke(amount);
            Debug.Log("OnCocoaLostCalled");
        }

    }

    public class EnemyEvents
    {
        public UnityAction OnEnemyAppearBasic;
        public UnityAction<EnemyHealth> OnEnemyAppear;
        public void CallOnEnemyAppear(EnemyHealth enemy)
        {
            Debug.Log("Appear");
            OnEnemyAppearBasic?.Invoke();
            OnEnemyAppear?.Invoke(enemy);
        }

        public UnityAction OnEnemyDiedBasic;
        public UnityAction<EnemyHealth> OnEnemyDied;
        public void CallOnEnemyDied(EnemyHealth enemy)
        {
            OnEnemyDiedBasic?.Invoke();
            OnEnemyDied?.Invoke(enemy);
        }
    }

    public class EnviromentEvents
    {
        public UnityAction OnEnviroAppearBasic;
        public UnityAction<EnviroId> OnEnviroAppear;
        public void CallOnEnviroAppear(EnviroId enviro)
        {
            Debug.Log("Appear");
            OnEnviroAppearBasic?.Invoke();
            OnEnviroAppear?.Invoke(enviro);
        }

        public UnityAction OnEnviroDiedBasic;
        public UnityAction<EnviroId> OnEnviroDied;
        public void CallOnEnemyDied(EnviroId enviro)
        {
            OnEnviroDiedBasic?.Invoke();
            OnEnviroDied?.Invoke(enviro);
        }
    }

    public class LevelEvents
    {
        public UnityAction OnLevelGeneratedBasic;
        public UnityAction<int[,]> OnLevelGenerated;
        public void CallOnLevelGenerated(int[,] layout)
        {
            OnLevelGeneratedBasic?.Invoke();
            OnLevelGenerated?.Invoke(layout);            
        }
    }
}

