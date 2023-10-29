using UnityEngine;
using Zenject;

public class EnemiesInstaller : MonoInstaller<EnemiesInstaller>
{
    [SerializeField] private Collider _levelArea;
    [SerializeField] private ChasingEnemy _enemyPrefab;
    [SerializeField] private Transform _enemiesParent;
    [SerializeField] private Transform _target;
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<EnemiesSpawner>().AsSingle();
    }

    public override void Start()
    {
        base.Start();

        var enemiesSpawner = Container.Resolve<IEnemiesSpawnerInitializer>();
        enemiesSpawner.Initialize(_levelArea.bounds, _enemyPrefab, _enemiesParent, _target);
    }
}
