using UnityEngine;

public class HeroJumpState : IExitableState, IEnterableState, IUpdatableState, IFixableState
{
    private const float Epsilon = 0.01f;

    private readonly IHeroAnimator _heroAnimator;
    private readonly IJumper _jumper;
    private readonly IGroundDetector _groundDetector;
    private readonly IMover _mover;
    private readonly PlayerControls _inputPlayer;

    private bool _hasLeftGrounded;

    private IStateChanger _stateCanger;

    public HeroJumpState(IHeroAnimator heroAnimator, IJumper jumper, IGroundDetector groundDetector, IMover mover, PlayerControls inputPlayer)
    {
        _heroAnimator = heroAnimator;
        _jumper = jumper;
        _groundDetector = groundDetector;
        _mover = mover;
        _inputPlayer = inputPlayer;
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateCanger = stateChanger;
    }

    public void Enter()
    {
        _jumper.Jump();

        _heroAnimator.PlayJump();
    }

    public void Exit()
    {
    }

    public void FixedUpdate(float deltaTime)
    {
        _mover.Move(_inputPlayer.MoveDirectionX);
    }

    public void Update(float deltaTime)
    {
        if (_hasLeftGrounded == false)
        {
            if (_jumper.Velocity.y > Epsilon)
                _hasLeftGrounded = true;

            return;
        }

        if (_hasLeftGrounded && _groundDetector.IsGrounded && _jumper.Velocity.y * _jumper.Velocity.y <= Epsilon)
            _stateCanger.ChangeState<HeroIdleState>();
    }

}