using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TigerBoss : BaseBrain<TigerBoss>
{
    [SerializeField]
    private Animator bossAnimator;
    public Animator BossAnimator => bossAnimator;

    [SerializeField]
    private Rigidbody2D bossrb;
    public Rigidbody2D BossRb => bossrb;

    [SerializeField]
    private float movementSpeed;
    public float MovementSpeed => movementSpeed;

    [SerializeField]
    private float attackDistance;
    public float AttackDistance => attackDistance;

    [SerializeField][Header("AttackVariables")]
    private Transform attackSpot;
    public Transform AttackSpot => attackSpot;

    [SerializeField]
    private Transform handPosition;
    public Transform HandPosition => handPosition;

    [SerializeField]
    private Transform centerOfMass;
    public Transform CenterOfMass => centerOfMass;

    [SerializeField]
    private Vector3 attackSize;
    public Vector3 AttackSize => attackSize;

    public UnityAction OnAnimationAttackedCallback;
    public UnityAction OnAnimationThrowCallback;
    public UnityAction OnAnimationDamageCompleted;

    [SerializeField][Header("Animations variables")]
    private float attackDuration;
    public float AttackDuration => attackDuration;

    public string ATTACK_KEY = "Attack";
    public string DAMAGE_KEY = "TakeDamage";

    public Transform testTransform;

    public Vector3 targetPosition;

    private void Start()
    {
        StartFollowState();
    }

    private void Update()
    {
        targetPosition = testTransform.position;
        UpdateChildState();
    }

    public void OnAnimationAttack()
    {
        OnAnimationAttackedCallback?.Invoke();
    }

    public void OnAnimationThrow()
    {
        OnAnimationThrowCallback?.Invoke();
    }

    public void AnimationDamageCompleted()
    {
        OnAnimationDamageCompleted?.Invoke();
    }

    public void StartFollowState()
    {
        ChangeState(new TigerBossFollowState());
    }

    public void StartAttackState()
    {
        ChangeState(new TigerBossAttackState());
    }

    public void StartDamageState()
    {
        ChangeState(new TigerBossDamageState());
    }

    public override void ChangeState(BaseState<TigerBoss> newState)
    {
        base.ChangeState(newState);

        currentState?.DeinitState(this);
        currentState = newState;
        currentState?.InitState(this);
    }

    public override void UpdateChildState()
    {
        base.UpdateChildState();
        currentState?.UpdateState();
    }

    public void TigerAttack(TigerTemplateBoss tiger)
    {
        var newState = new TigerBossDamageState();
        newState.tigerToThrow = tiger;
        ChangeState(newState);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackSpot.position, attackSize);
    }
}
