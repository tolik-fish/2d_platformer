using UnityEngine;

public class SnakeMoveState : IExitableState, IEnterableState, IUpdatableState, IFixableState
{
    private const float Epsilon = 0.01f;

    private readonly SnakeAnimator _animator;
    private readonly IMover _mover;

    private IStateChanger _stateChanger;

    public SnakeMoveState(SnakeAnimator animator, IMover mover)
    {
        _animator = animator;
        _mover = mover;
    }

    public void Enter()
    {
        _animator.PlayMove();
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
    }

    public void FixedUpdate(float deltaTime)
    {
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }
}
