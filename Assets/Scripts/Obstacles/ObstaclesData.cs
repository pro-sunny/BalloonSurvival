using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObstaclesData : ScriptableObject
{
    [SerializeField] private int _obstaclesOnLevel;
    [SerializeField] private List<Vector3> _positions;
    
    public List<Vector3> Positions => _positions;
    public int ObstaclesOnLevel => _obstaclesOnLevel;
}
