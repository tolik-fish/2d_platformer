public class HeroMoveState : IEnterableState, IExitableState, IUpdatableState, IFixableState
{
    private readonly IHeroAnimator _heroAnimator;
    private readonly IMover _mover;

    private IStateChanger _stateChanger;

    private PlayerControls _playerInput;

    public HeroMoveState(IHeroAnimator heroAnimator, IMover mover, PlayerControls playerControls)
    {
        _heroAnimator = heroAnimator;
        _mover = mover;
        _playerInput = playerControls;
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }

    public void Enter()
    {
        _heroAnimator.PlayMove();

        _playerInput.JumpPressed += ChangeToJumpState;
        _playerInput.AttackPressed += ChangeToAttackState;
    }

    public void Exit()
    {
        _playerInput.JumpPressed -= ChangeToJumpState;
        _playerInput.AttackPressed -= ChangeToAttackState;
    }

    public void FixedUpdate(float deltaTime)
    {
        _mover.Move(_playerInput.MoveDirectionX);
    }

    public void Update(float deltaTime)
    {
        if (_playerInput.MoveDirectionX == 0)
            _stateChanger.ChangeState<HeroIdleState>();
    }

    private void ChangeToJumpState()
    {
        _stateChanger.ChangeState<HeroJumpState>();
    }
    private void ChangeToAttackState() =>
    _stateChanger?.ChangeState<HeroAttackState>();
}