using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position;
    }

    private void Update()
    {
        transform.position = _offset + _target.position;
    }
}
