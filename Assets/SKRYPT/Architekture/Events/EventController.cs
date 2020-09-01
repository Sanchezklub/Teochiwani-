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
    public ItemEvents itemEvents;
    public WeaponEvents weaponEvents;

    private void Awake()
    {
        instance = this;
        playerEvents = new PlayerEvents();
        enemyEvents = new EnemyEvents();
        levelEvents = new LevelEvents();
        enviromentEvents = new EnviromentEvents();
        weaponEvents = new WeaponEvents();
        itemEvents = new ItemEvents();
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

        public UnityAction OnMaxhealthValueChangeBasic;
        public UnityAction<float> OnMaxhealthValueChange;
        public void CallOnMaxhealthValueChange(float amount)
        {
            OnMaxhealthValueChangeBasic?.Invoke();
            OnMaxhealthValueChange?.Invoke(amount);
        }


    }

    public class EnemyEvents
    {
        public UnityAction OnEnemyAppearBasic;
        public UnityAction<EnemyHealth> OnEnemyAppear;
        public void CallOnEnemyAppear(EnemyHealth enemy)
        {
            //Debug.Log("EnemyAppear");
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
        public UnityAction OnEnemyGetDamageBasic;
        public UnityAction<EnemyHealth> OnEnemyGetDamage;
        public void CallOnEnemyGetDamage(EnemyHealth enemy)
        {
            OnEnemyGetDamageBasic?.Invoke();
            OnEnemyGetDamage?.Invoke(enemy);
        }

        public UnityAction OnBossDiedBasic;
        public UnityAction<EnemyHealth> OnBossDied;

        public void CallOnBossDied(EnemyHealth boss)
        {
            OnBossDiedBasic?.Invoke();
            OnBossDied?.Invoke(boss);
        }

        public UnityAction<float> OnFireDamageDealt;
        public UnityAction OnFireDamageDealtBasic;

        public void CallOnFireDamageDealt(float damage)
        {
            OnFireDamageDealtBasic?.Invoke();
            OnFireDamageDealt?.Invoke(damage);
        }

        public UnityAction<float> OnPoisonDamageDealt;
        public UnityAction OnPoisonDamageDealtBasic;

        public void CallOnPoisonDamageDealt(float damage)
        {
            OnPoisonDamageDealtBasic?.Invoke();
            OnPoisonDamageDealt?.Invoke(damage);
        }

        public UnityAction<float> OnBleedDamageDealt;
        public UnityAction OnBleedDamageDealtBasic;

        public void CallOnBleedDamageDealt(float damage)
        {
            OnBleedDamageDealtBasic?.Invoke();
            OnBleedDamageDealt?.Invoke(damage);
        }
    }

    public class EnviromentEvents
    {
        public UnityAction OnEnviroAppearBasic;
        public UnityAction<EnviroId> OnEnviroAppear;
        public void CallOnEnviroAppear(EnviroId enviro)
        {
            //Debug.Log("EnviroAppear");
            OnEnviroAppearBasic?.Invoke();
            OnEnviroAppear?.Invoke(enviro);
        }

        public UnityAction OnEnviroDiedBasic;
        public UnityAction<EnviroId> OnEnviroDied;
        public void CallOnEnviroDied(EnviroId enviro)
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
            Debug.Log("On level generated called");
        }
        public UnityAction OnChunkGeneratedBasic;
        public void CallOnChunkGenerated()
        {
            OnChunkGeneratedBasic?.Invoke();
        }


        public UnityAction OnLevelEndedBasic;

        public void CallOnLevelEnded()
        {
            OnLevelEndedBasic?.Invoke();
        }

        public UnityAction OnRoomGeneratedBasic;
        public UnityAction<RoomId> OnRoomGenerated;

        public void CallOnRoomGenerated(RoomId id)
        {
            OnRoomGeneratedBasic?.Invoke();
            OnRoomGenerated?.Invoke(id);
        }
    }
    public class ItemEvents
    {
        public UnityAction OnItemAppearBasic;
        public UnityAction<BaseItem> OnItemAppear;
        public void CallOnItemAppear(BaseItem item)
        {
            //Debug.Log("ItemAppear");
            OnItemAppearBasic?.Invoke();
            OnItemAppear?.Invoke(item);
        }

        public UnityAction OnItemDiedBasic;
        public UnityAction<BaseItem> OnItemDied;
        public void CallOnItemDied(BaseItem item)
        {
            OnItemDiedBasic?.Invoke();
            OnItemDied?.Invoke(item);
        }
    }

    public class WeaponEvents
    {
        public UnityAction OnWeaponAppearBasic;
        public UnityAction<BaseWeapon> OnWeaponAppear;
        public void CallOnWeaponAppear(BaseWeapon weapon)
        {
            Debug.Log("WeaponAppear");
            OnWeaponAppearBasic?.Invoke();
            OnWeaponAppear?.Invoke(weapon);
        }

        public UnityAction OnWeaponDiedBasic;
        public UnityAction<BaseWeapon> OnWeaponDied;
        public void CallOnWeaponDied(BaseWeapon weapon)
        {
            OnWeaponDiedBasic?.Invoke();
            OnWeaponDied?.Invoke(weapon);
        }

        public UnityAction OnWeaponPickupBasic;
        public UnityAction<BaseWeapon, BaseWeapon> OnWeaponPickup;

        public void CallOnWeaponPickup(BaseWeapon OldWeapon, BaseWeapon NewWeapon)
        {
            OnWeaponPickupBasic?.Invoke();
            OnWeaponPickup?.Invoke(OldWeapon, NewWeapon);
        }


    }
}

