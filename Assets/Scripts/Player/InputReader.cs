using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode JumpKey = KeyCode.Space;
    private const KeyCode AttackKey = KeyCode.L;

    private Player _player;

    public event Action Standing;
    public event Action Jumping;
    public event Action<float> Running;
    public event Action Attacking;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Move();

        Jump();

        Attack();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);

        if (direction != 0)
            Running?.Invoke(direction);
        else
            Standing?.Invoke();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(JumpKey))
            Jumping?.Invoke();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(AttackKey))
            Attacking?.Invoke();
    }
}