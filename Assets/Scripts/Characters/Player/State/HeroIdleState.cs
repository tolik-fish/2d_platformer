using UnityEngine;
using UnityEngine.EventSystems;

public class HeroIdleState : IExitableState, IEnterableState, IUpdatableState
{
    private readonly IHeroAnimator _heroAnimator;
    private readonly IGroundDetector _groundDetector;

    private readonly PlayerControls _playerInput;

    private IStateChanger _stateChanger;

    public HeroIdleState(IHeroAnimator heroAnimator, IGroundDetector groundDetector, PlayerControls playerControls)
    {
        _heroAnimator = heroAnimator;
        _groundDetector = groundDetector;
        _playerInput = playerControls;
    }

    public void Enter()
    {
        _heroAnimator.PlayIdle();

        _playerInput.JumpPressed += ChangeToJumpState;
        _playerInput.AttackPressed += ChangeToAttackState;
    }

    public void Exit()
    {
        _playerInput.JumpPressed -= ChangeToJumpState;
        _playerInput.AttackPressed -= ChangeToAttackState;
    }

    public void Update(float deltaTime)
    {
        if (_playerInput.MoveDirectionX != 0)
            _stateChanger.ChangeState<HeroMoveState>();

    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }

    private void ChangeToJumpState()
    {
        if (_groundDetector.IsGrounded == true)
            _stateChanger.ChangeState<HeroJumpState>();
    }

    private void ChangeToAttackState() =>
        _stateChanger?.ChangeState<HeroAttackState>();
}