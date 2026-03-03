public class SnakeAttackState : IExitableState, IEnterableState, IUpdatableState
{
    private readonly ISnakeAnimator _snakeAnimator;
    private readonly IAttacker _attacker;

    private float _attackAnimationLength = 1f;

    private IStateChanger _stateChanger;

    public SnakeAttackState(ISnakeAnimator animator, IAttacker attacker)
    {
        _snakeAnimator = animator;
        _attacker = attacker;
    }

    public void Enter()
    {
        _snakeAnimator.PlayAttack();

        _attacker.Attack();
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
        _attackAnimationLength -= deltaTime;

        if (_attackAnimationLength <= 0f)
            _stateChanger.ChangeState<SnakeIdleState>();
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }
}