using Zenject;

public class StateMachineInstaller : MonoInstaller<StateMachineInstaller>
{
     private GameStateMachine _gameStateMachine;

    public override void InstallBindings()
    {
        _gameStateMachine = new GameStateMachine(Container);
        Container.BindInterfacesAndSelfTo<GameStateMachine>().FromInstance(_gameStateMachine).AsSingle();
    }
}
