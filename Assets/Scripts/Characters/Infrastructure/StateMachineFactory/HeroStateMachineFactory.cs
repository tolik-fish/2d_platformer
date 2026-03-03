using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachineFactory
{
    private readonly IHeroAnimator _heroAnimator;
    private readonly IMover _mover;
    private readonly IJumper _jumper;
    private readonly IAttacker _heroAttacker;
    private readonly IGroundDetector _groundDetector;

    private readonly PlayerControls _playerController;
    private readonly Rigidbody2D _rigidbody;

    public HeroStateMachineFactory(IHeroAnimator heroAnimator, IMover mover, IJumper jumper, IAttacker heroAttacker, IGroundDetector groundDetector, PlayerControls playerController)
    {
        _heroAnimator = heroAnimator;
        _mover = mover;
        _jumper = jumper;
        _heroAttacker = heroAttacker;
        _groundDetector = groundDetector;
        _playerController = playerController;
    }

    public StateMachine Create()
    {
        List<IExitableState> states = new List<IExitableState>()
        {
            new HeroIdleState(_heroAnimator, _groundDetector, _playerController),
            new HeroMoveState(_heroAnimator, _mover, _playerController),
            new HeroJumpState(_heroAnimator, _jumper, _groundDetector, _mover, _playerController),
            new HeroAttackState(_heroAnimator, _heroAttacker)
        };

        StateMachine stateMachine = new StateMachine(states);

        foreach (IExitableState state in states)
            state.SetStateChanger(stateMachine);

        stateMachine.ChangeState<HeroIdleState>();

        return stateMachine;
    }
}