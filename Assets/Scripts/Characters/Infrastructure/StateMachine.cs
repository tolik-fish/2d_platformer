using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : IStateChanger, IStateMachineUpdater
{
    public readonly Dictionary<Type, IExitableState> _states;

    private IExitableState _currentState;

    public StateMachine(List<IExitableState> states)
    {
        foreach (IExitableState state in states)
            state.SetStateChanger(this);

        _states = states.ToDictionary(type => type.GetType(), value => value);
    }

    public void UpdateState(float deltaTime)
    {
        if (_currentState is IUpdatableState updatableState)
            updatableState.Update(deltaTime);
    }

    public void FixedUpdateState(float deltaTime)
    {
        if (_currentState is IFixableState updatableState)
            updatableState.FixedUpdate(deltaTime);
    }

    public void ChangeState<T>() where T : IExitableState
    {
        if (_states.TryGetValue(typeof(T), out IExitableState newState))
            ChangeState(newState);
    }

    private void ChangeState(IExitableState newState)
    {
        if (newState == _currentState)
            return;

        _currentState?.Exit();
        _currentState = newState;

        if (_currentState is IEnterableState enterableState)
            enterableState.Enter();
    }
}