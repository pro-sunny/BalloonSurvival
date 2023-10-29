using UnityEngine;

public class StaticEnemy : Enemy
{
    [SerializeField] private CapsuleCollider _collider;

    public float Radius => _collider.radius;
}
