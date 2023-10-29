using UnityEngine;

public class GamePlayState : IState
{
    private IEnemiesSpawner _spawner;
    private IObstaclesSpawner _obstaclesSpawner;

    private float _currentEnemiesSpawnDelay;
    private ILevelConfigs _levelConfigs;
    private IScoreUpdater _scoreUpdater;
    private IJoystickActivator _joystickActivator;

    public GamePlayState(IEnemiesSpawner spawner, IObstaclesSpawner obstaclesSpawner, 
        ILevelConfigs levelConfigs, IScoreUpdater scoreUpdater, IJoystickActivator joystickActivator)
    {
        _obstaclesSpawner = obstaclesSpawner;
        _spawner = spawner;
        _levelConfigs = levelConfigs;
        _scoreUpdater = scoreUpdater;
        _joystickActivator = joystickActivator;
    }
    
    public void Enter()
    {
        _obstaclesSpawner.SpawnObstacles();
    }

    public void Tick()
    {
        _currentEnemiesSpawnDelay += Time.deltaTime;
        if (_currentEnemiesSpawnDelay > _levelConfigs.EnemiesSpawnDelay)
        {
            _spawner.SpawnEnemies();
            _currentEnemiesSpawnDelay = 0;
        }
        
        _scoreUpdater.Update();
    }

    public void Exit()
    {
        _joystickActivator.SetActive(false);
    }
}