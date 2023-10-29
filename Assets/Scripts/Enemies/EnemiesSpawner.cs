using UnityEngine;

public interface IEnemiesSpawnerInitializer
{
    public void Initialize(Bounds levelBounds, ChasingEnemy enemy, Transform parent, Transform target);
}

public interface IEnemiesSpawner
{
    public void SpawnEnemies();
}

public class EnemiesSpawner : IEnemiesSpawner, IEnemiesSpawnerInitializer
{
    private IObstacleOverlapResolver _obstacleOverlapResolver;
    private Bounds _levelBounds;
    private Transform _parent;
    private ChasingEnemy _enemy;
    private Transform _target;

    public EnemiesSpawner(IObstacleOverlapResolver obstacleOverlapResolver)
    {
        _obstacleOverlapResolver = obstacleOverlapResolver;
    }
    
    public void Initialize(Bounds levelBounds, ChasingEnemy enemy, Transform parent, Transform target)
    {
        _levelBounds = levelBounds;
        _parent = parent;
        _enemy = enemy;
        _target = target;
    }

    public void SpawnEnemies()
    {
        var position = GetSpawnPoint();
        var enemy = Object.Instantiate(_enemy, position, Quaternion.identity, _parent);
        enemy.SetTarget(_target);
    }
    
    private Vector3 GetSpawnPoint()
    {
        var spawnPoint = _levelBounds.RandomPointInBounds();
        if (_obstacleOverlapResolver.IsPointInsideSpawnedObstacles(spawnPoint))
        {
            return GetSpawnPoint();
        }
        return spawnPoint;
    }
}
