using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMoveable, ITriggerCheckable
{
    // IDamageable
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    public float CurrentHealth { get; set; }

    // IEnemyMovable
    public Rigidbody2D rb { get; set; }
    public bool isFacingRight { get; set; } = true;

    // ITriggerCheckable
    public bool IsAggroed { get; set; }
    public bool IsWithinStrikingDistance { get; set; }

    #region State Machine variables

    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState idleState { get; set; }
    public EnemyAttackState attackState { get; set; }
    public EnemyChaseState chaseState { get; set; }

    #endregion

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        idleState = new EnemyIdleState(this, StateMachine);
        attackState = new EnemyAttackState(this, StateMachine);
        chaseState = new EnemyChaseState(this, StateMachine);
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
        rb = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(idleState);
    }

    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate();
        //StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    #region Idle Variables

    // public GameObject BulletPrefab;
    [SerializeField] public float RandomMovementRange = 5f;
    [SerializeField] public float RandomMovementSpeed = 1f;


    #endregion

    #region Health/Die functions
    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;

        if (CurrentHealth <= 0f)
        {
            Debug.Log("Enemy Damaged");
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    #endregion

    #region Movement

    public void MoveEnemy(Vector2 velocity)
    {
        rb.velocity = velocity;
        CheckForLeftOrRightFacing(velocity);
    }

    
    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        /*
        if (isFacingRight && velocity.x < 0f)
        {
            Vector3 rotater = new Vector3(transform.rotation.x, 100f, transform.position.z);
            transform.rotation = Quaternion.Euler(rotater);
            isFacingRight = !isFacingRight;
        }
        
        else if(!isFacingRight && velocity.x > 0f)
        {
            Vector3 rotater = new Vector3(transform.rotation.x, 0f, transform.position.z);
            transform.rotation = Quaternion.Euler(rotater);
            isFacingRight = !isFacingRight;
        }
        */
    }
    
    #endregion

    #region Animation Triggers

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepSound
    }
    #endregion

    #region Distance checks

    public void SetAggroStatus(bool isAggroed)
    {
        IsAggroed = isAggroed;
    }

    public void SetStrikingDistance(bool isWithinStrikingDistance)
    {
        IsWithinStrikingDistance = isWithinStrikingDistance;
    }

    #endregion
}
