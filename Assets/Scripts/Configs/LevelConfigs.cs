using UnityEngine;

[CreateAssetMenu]
public class LevelConfigs : ScriptableObject
{
    [SerializeField, Tooltip("Delay between enemies spawn in seconds")] 
    private float _enemiesSpawnDelay;

    public float EnemiesSpawnDelay => _enemiesSpawnDelay;
}
