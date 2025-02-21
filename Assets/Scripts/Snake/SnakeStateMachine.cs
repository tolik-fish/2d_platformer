using UnityEngine;

[RequireComponent(typeof(SnakeAnimator),typeof(SpriteRenderer), typeof(Flipper))]
public class SnakeStateMachine : MonoBehaviour
{
    private Snake _snake;
    private SnakeAnimator _animator;
    private Flipper _flipper;

    private void Awake()
    {
        _snake = GetComponent<Snake>();
        _animator = GetComponent<SnakeAnimator>();
        _flipper = GetComponent<Flipper>();
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

        _flipper.TurnAround(value);
    }

    private void PlayAnimationStanding() =>
        _animator.PlayStand();
}