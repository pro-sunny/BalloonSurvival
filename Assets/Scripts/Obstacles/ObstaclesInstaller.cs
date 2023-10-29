using UnityEngine;
using Zenject;

public class ObstaclesInstaller : MonoInstaller<ObstaclesInstaller>
{
    [SerializeField] private ObstaclesData _obstaclesData;
    [SerializeField] private StaticEnemy _obstaclePrefab;
    [SerializeField] private Transform _obstaclesParent;
    
    
    public override void InstallBindings()
    {
        var obstaclesSpawner = new ObstaclesSpawner(_obstaclesData, _obstaclePrefab, _obstaclesParent);
        Container.BindInterfacesTo<ObstaclesSpawner>().FromInstance(obstaclesSpawner).AsSingle();
    }
}
