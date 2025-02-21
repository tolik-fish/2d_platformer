using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SnakeStateMachine), typeof(SnakeMover))]
public class Snake : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;

    private float _direction;
    private float _threshold = 0.1f;
    private int _index;

    private SnakeMover _mover;

    public event Action<float> Moving;
    public event Action Standing;

    private void Awake()
    {
        _mover = GetComponent<SnakeMover>();
    }

    private void Start()
    {
        _index = 0;

        CalculateDirection();
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Move();

        if (IsReachPoint())
        {
            _index = GetNextIndex();

            CalculateDirection();
        }
    }

    private void Move()
    {
        _mover.Move(_direction);

        Moving?.Invoke(_direction);
    }

    private void CalculateDirection()
    {
        float max = 1f;
        float min = -1f;

        _direction = Mathf.Clamp(_points[_index].position.x - transform.position.x, min, max);
    }

    private bool IsReachPoint() =>
        Mathf.Abs(transform.position.x - _points[_index].position.x) < _threshold;

    private int GetNextIndex() =>
         ++_index % _points.Count;
}