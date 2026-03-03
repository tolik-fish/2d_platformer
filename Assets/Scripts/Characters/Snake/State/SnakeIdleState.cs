using UnityEngine;

public class SnakeIdleState : IExitableState, IEnterableState, IUpdatableState
{
    private const float Epsilon = 0.01f;

    private readonly ISnakeAnimator _snakeAnimator;

    private IStateChanger _stateChanger;

    public SnakeIdleState(ISnakeAnimator animator)
    {
        _snakeAnimator = animator;
    }

    public void Enter()
    {
        _snakeAnimator.PlayIdle();
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }
}