using UnityEngine;
using Zenject;

public class ConfigsInstaller : MonoInstaller<ConfigsInstaller>
{
    [SerializeField] private LevelConfigs _levelConfigs;
    
    public override void InstallBindings()
    {
        var levelConfigsProvider = new LevelConfigsProvider(_levelConfigs);
        
        Container.BindInterfacesTo<LevelConfigsProvider>().FromInstance(levelConfigsProvider).AsSingle();
    }
}
