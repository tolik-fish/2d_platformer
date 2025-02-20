using System;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(SpriteRenderer))]
public class SnakeStateManager : MonoBehaviour
{
    private SpriteRenderer _render;
    private Snake _snake;

    public event Action Standing;
    public event Action Running;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _snake = GetComponent<Snake>();
    }

    private void OnEnable()
    {
        _snake.Moving += InvokeStateRun;
        _snake.Standing += InvokeStateStand;
    }

    private void OnDisable()
    {
        _snake.Moving -= InvokeStateRun;
        _snake.Standing -= InvokeStateStand;
    }

    private void InvokeStateStand()
    {
        Standing?.Invoke();
    }

    private void InvokeStateRun(float value)
    {
        Running?.Invoke();

        if (value < 0)
            _render.flipX = true;
        else if (value > 0)
            _render.flipX = false;
    }
}