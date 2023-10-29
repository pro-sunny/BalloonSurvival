using System.Collections.Generic;
using UnityEngine;

public interface IObstaclesSpawner
{
    public void SpawnObstacles();
}

public interface IObstacleOverlapResolver
{
    public bool IsPointInsideSpawnedObstacles(Vector3 point);
}

public class ObstaclesSpawner : IObstaclesSpawner, IObstacleOverlapResolver
{
    private ObstaclesData _obstaclesData;
    private StaticEnemy _obstacle;
    private Dictionary<int, StaticEnemy> _occupiedPositions;
    private Transform _parent;

    public ObstaclesSpawner(ObstaclesData obstaclesData, StaticEnemy obstacle, Transform parent)
    {
        _obstaclesData = obstaclesData;
        _obstacle = obstacle;
        _parent = parent;
    }

    public void SpawnObstacles()
    {
        _occupiedPositions = new Dictionary<int, StaticEnemy>();
        for (int i = 0; i < _obstaclesData.ObstaclesOnLevel; i++)
        {
            var index = GetSpawnPositionIndex();
            var position = _obstaclesData.Positions[index];
            var obstacle = Object.Instantiate(_obstacle, position, Quaternion.identity, _parent);
            _occupiedPositions.Add(index, obstacle);
        }
    }

    public bool IsPointInsideSpawnedObstacles(Vector3 point)
    {
        var pointFlat = new Vector3(point.x, 0, point.z);
        foreach (var position in _occupiedPositions)
        {
            var occupiedPosition = _obstaclesData.Positions[position.Key];
            var positionFlat = new Vector3(occupiedPosition.x, 0, occupiedPosition.z);
            var radius = position.Value.Radius;
            
            if (Vector3.Distance(positionFlat, pointFlat) < radius)
            {
                return false;
            }
        }

        return false;
    }
    
    private int GetSpawnPositionIndex()
    {
        var index = Random.Range(0, _obstaclesData.Positions.Count);
        if (_occupiedPositions.ContainsKey(index))
        {
            return GetSpawnPositionIndex();
        }

        return index;
    }
}
