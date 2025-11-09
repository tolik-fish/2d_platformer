// Ignore Spelling: Cooldown

using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SnakeStateMachine), typeof(SnakeAI))]
[RequireComponent(typeof(Health))]
public class Snake : MonoBehaviour
{
    [SerializeField] private float _viewDistance = 10f;
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private float _detectionTime = 2f;
    [SerializeField] private float _attackCooldown = 2f;
    [SerializeField] private float _attackDamage = 10f;

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _playerLayerMask;

    private SnakeMover _mover;
    private Health _health;

    public bool IsLookDirectRightSide => transform.rotation.y == 0;

    public event Action<float> Moving;
    public event Action Standing;
    public event Action Attacking;

    private void Awake()
    {
        _mover = GetComponent<SnakeMover>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public void Move(float direction)
    {
        _mover.Move(direction);

        Moving?.Invoke(direction);
    }

    public void Stand() => Standing?.Invoke();

    public float GetViewDistance() => _viewDistance;

    public float GetAttackDistance() => _attackRange;

    public float GetDetectionTime() => _detectionTime;

    public float GetAttackCooldown() => _attackCooldown;

    public void Die() => Destroy(gameObject);

    public void Attack()
    {
        Vector2 attackDirection;

        if (transform.rotation.y >= 0)
            attackDirection = Vector2.right;
        else
            attackDirection = Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(_attackPoint.position, attackDirection, _attackRange, _playerLayerMask);

        if (hit.collider != null)
        {
            Health playerHealth;

            if (hit.collider.TryGetComponent(out playerHealth))
                if (playerHealth != null)
                    playerHealth.TakeDamage(_attackDamage);

            Attacking?.Invoke();
        }
    }
}