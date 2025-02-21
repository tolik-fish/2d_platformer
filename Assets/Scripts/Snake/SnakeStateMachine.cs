using System;
using UnityEngine;

[RequireComponent(typeof(SnakeAnimator),typeof(SpriteRenderer))]
public class SnakeStateMachine : MonoBehaviour
{
    private SpriteRenderer _render;
    private Snake _snake;
    private SnakeAnimator _animator;

    public event Action Standing;
    public event Action Running;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _snake = GetComponent<Snake>();
        _animator = GetComponent<SnakeAnimator>();
    }

    private void OnEnable()
    {
        _snake.Moving += PlayAnimationMoving;
        _snake.Standing += PlayAnimationStanding;
    }

    private void OnDisable()
    {
        _snake.Moving -= PlayAnimationMoving;
        _snake.Standing -= PlayAnimationStanding;
    }

    private void PlayAnimationMoving(float value)
    {
        _animator.PlayRun();

        if (value < 0)
            _render.flipX = true;
        else 
            _render.flipX = false;
    }

    private void PlayAnimationStanding() =>
        _animator.PlayStand();
}