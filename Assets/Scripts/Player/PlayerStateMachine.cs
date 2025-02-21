using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(GroundDetector), typeof(Flipper))]
public class PlayerStateMachine : MonoBehaviour
{
    private InputReader _input;
    private GroundDetector _groundDetector;
    private PlayerAnimator _animator;
    private Flipper _flipper;

    private void Awake()
    {
        _input = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _animator = GetComponent<PlayerAnimator>();
        _flipper = GetComponent<Flipper>();
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

        _flipper.TurnAround(value);
    }
}