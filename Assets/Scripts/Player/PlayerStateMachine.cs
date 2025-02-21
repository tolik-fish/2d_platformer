using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(GroundDetector))]
public class PlayerStateMachine : MonoBehaviour
{
    private InputReader _input;
    private GroundDetector _groundDetector;
    private SpriteRenderer _render;
    private PlayerAnimator _animator;

    private void Awake()
    {
        _input = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _render = GetComponent<SpriteRenderer>();
        _animator = GetComponent<PlayerAnimator>();
    }

    private void OnEnable()
    {
        _input.Standing += PlayAnimationStanding;
        _input.Running += PlayAnimationRunning;
    }

    private void OnDisable()
    {
        _input.Standing -= PlayAnimationStanding;
        _input.Running -= PlayAnimationRunning;
    }

    private void Update()
    {
        if (_groundDetector.IsGrounded == false)
            _animator.PlayFall();
    }

    private void PlayAnimationStanding()
    {
        if (_groundDetector.IsGrounded)
            _animator.PlayStand();
    }

    private void PlayAnimationRunning(float value)
    {
        if (_groundDetector.IsGrounded)
            _animator.PlayRun();

        if (value < 0)
            _render.flipX = true;
        else 
            _render.flipX = false;
    }
}