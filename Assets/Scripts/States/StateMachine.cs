using System;
using System.Collections.Generic;

public abstract class StateMachine : IStateMachine
{
    private readonly Dictionary<Type, IState> registeredStates;
    protected IState _currentState;

    public StateMachine() => 
        registeredStates = new Dictionary<Type, IState>();

    public void Enter<TState>() where TState : class, IState
    {
        TState newState = ChangeState<TState>();
        newState.Enter();
    }

    public void RegisterState<TState>(TState state) where TState : IState =>
        registeredStates.Add(typeof(TState), state);

    private TState ChangeState<TState>() where TState : class, IState
    {
        if(_currentState != null)
            _currentState.Exit();
      
        TState state = GetState<TState>();
        _currentState = state;
      
        return state;
    }
    
    private TState GetState<TState>() where TState : class, IState => 
        registeredStates[typeof(TState)] as TState;
}