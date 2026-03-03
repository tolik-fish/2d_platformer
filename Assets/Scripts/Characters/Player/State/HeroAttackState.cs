using UnityEngine;

public class HeroAttackState : IExitableState, IEnterableState, IUpdatableState
{
    private readonly IHeroAnimator _heroAnimator;
    private readonly IAttacker _attacker;

    private float _attackAnimationLength = 0.5f;

    private IStateChanger _stateChanger;

    public HeroAttackState(IHeroAnimator heroAnimator, IAttacker attacker)
    {
        _heroAnimator = heroAnimator;
        _attacker = attacker;
    }

    public void Enter()
    {
        _heroAnimator.PlayAttack();

        _attacker.Attack();
    }

    public void Exit()
    {
    }

    public void Update(float deltaTime)
    {
        _attackAnimationLength -= deltaTime;

        if (_attackAnimationLength <= 0f)
        {
            _stateChanger.ChangeState<HeroIdleState>();

            _attackAnimationLength = 0.5f;
        }
    }

    public void SetStateChanger(IStateChanger stateChanger)
    {
        _stateChanger = stateChanger;
    }
}