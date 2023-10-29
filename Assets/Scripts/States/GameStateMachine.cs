using Zenject;

public class GameStateMachine : StateMachine, IInitializable, ITickable
{
    private DiContainer _container;

    public GameStateMachine(DiContainer container)
    {
        _container = container;
    }
    
    public void Initialize()
    {
        RegisterGamePlayState();
        RegisterGameOverState();
        
        Enter<GamePlayState>();
    }
    
    private void RegisterGamePlayState()
    {
        var state = _container.Instantiate<GamePlayState>();
        RegisterState(state);
    }

    private void RegisterGameOverState()
    {
        var state = _container.Instantiate<GameOverState>();
        RegisterState(state);
    }

    public void Tick()
    {
        _currentState.Tick();
    }
}
