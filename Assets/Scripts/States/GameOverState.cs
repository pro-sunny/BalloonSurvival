using System.Threading.Tasks;

public class GameOverState : IState
{
    private IScoreWindowActivator _scoreWindowActivator;

    public GameOverState(IScoreWindowActivator scoreWindowActivator)
    {
        _scoreWindowActivator = scoreWindowActivator;
    }
    public void Enter()
    {
        _scoreWindowActivator.Activate(1);
    }

    public void Tick()
    {
    }

    public void Exit()
    {
    }
}
