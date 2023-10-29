using UnityEngine;
using Random = UnityEngine.Random;

public class ChasingEnemy : Enemy
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private float _height;
    
    private Transform _target;
    
    private void Start()
    {
        SetRandomColor();
        var pos = transform.position;
        transform.position = new Vector3(pos.x, _height, pos.z);
    }

    private void SetRandomColor()
    {
        _mesh.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.forward * _moveSpeed;
        
        var direction = _target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction);
        _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed));
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
