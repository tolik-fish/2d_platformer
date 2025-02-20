using System;
using UnityEngine;

[RequireComponent(typeof(InputControl), typeof(GroundDetector))]
public class PlayerStateManager : MonoBehaviour
{
    private InputControl _input;
    private GroundDetector _groundDetector;
    private SpriteRenderer _render;

    public event Action Standing;
    public event Action Running;
    public event Action Falling;

    private void Awake()
    {
        _input = GetComponent<InputControl>();
        _groundDetector = GetComponent<GroundDetector>();
        _render = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _input.Standing += InvokeStateStand;
        _input.Running += InvokeStateRun;
    }

    private void OnDisable()
    {
        _input.Standing -= InvokeStateStand;
        _input.Running -= InvokeStateRun;
    }

    private void Update()
    {
        if (_groundDetector.IsGrounded == false)
            InvokeStateFallen();
    }

    private void InvokeStateStand()
    {
        if (_groundDetector.IsGrounded)
            Standing?.Invoke();
    }

    private void InvokeStateRun(float value)
    {
        if (_groundDetector.IsGrounded)
            Running?.Invoke();

        if (value < 0)
            _render.flipX = true;
        else if (value > 0)
            _render.flipX = false;
    }

    private void InvokeStateFallen() =>
        Falling?.Invoke();
}