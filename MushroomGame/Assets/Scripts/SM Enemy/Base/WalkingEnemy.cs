using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;

public class WalkingEnemy : MonoBehaviour, IDamageable, IEnemyMoveable
{
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public Rigidbody2D rb { get; set; }
    public bool isFacingRight { get; set; } = true;
    public float walkSpeed { get; set; }
    public Vector3 direction { get; set; }
    public Vector3 previousPosition { get; set; }

    public EnemyStateMachine stateMachine { get; set; }
    public EnemyPatrol patrolState { get; set; }
    public EnemyHunt huntState { get; set; }
    public EnemyAttack attackState { get; set; }


    public void Awake()
    {
        stateMachine = new EnemyStateMachine();

        huntState = new EnemyHunt(this, stateMachine);
        patrolState = new EnemyPatrol(this, stateMachine);
        attackState = new EnemyAttack(this, stateMachine);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        previousPosition = transform.position;

        rb = GetComponent<Rigidbody2D>();

        stateMachine.Initialize(patrolState);
    }

    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
        stateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

    public enum AnimationTriggerType
    {
        EnemyDamaged,
        PlayFootstepSound
    }

    private void Update()
    {
        stateMachine.CurrentEnemyState.FrameUpdate();

        if (previousPosition != gameObject.transform.position)
        {
            direction = (previousPosition - gameObject.transform.position).normalized;
            previousPosition = transform.position;
        }
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentEnemyState.PhysicsUpdate();
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void MoveEnemy(Vector2 velocity)
    {
        if (direction.x == 1)
        {
            rb.velocity = new Vector2(walkSpeed, 0f);
        }
        else if (direction.x == -1)
        {
            rb.velocity = new Vector2(-walkSpeed, 0f);
        }
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if (isFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
        else if (!isFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isFacingRight = !isFacingRight;
        }
    }
}
