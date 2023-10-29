public interface ILevelConfigs
{
    public float EnemiesSpawnDelay { get; }
}

public class LevelConfigsProvider : ILevelConfigs
{
    public float EnemiesSpawnDelay => _levelConfigs.EnemiesSpawnDelay;
    
    private LevelConfigs _levelConfigs;

    public LevelConfigsProvider(LevelConfigs levelConfigs)
    {
        _levelConfigs = levelConfigs;
    }
}
