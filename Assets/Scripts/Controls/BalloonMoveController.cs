using UnityEngine;

public class BalloonMoveController : MonoBehaviour
{
    [SerializeField] private JoystickController _joystickController;
    [SerializeField] private Transform _balloonTransform;
    [SerializeField] private Rigidbody _balloonRigidbody;
    [SerializeField] private float _maxPivotAngle;
    [SerializeField] private float _speed;
    
    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = _balloonTransform.position;
    }

    void Update()
    {
        var input = _joystickController.Input;
        Quaternion desiredPivot = Quaternion.Euler(new Vector3(_maxPivotAngle*input.y, 0, _maxPivotAngle*input.x*(-1)));
        _balloonTransform.rotation = desiredPivot;
    }

    private void FixedUpdate()
    {
        var input = _joystickController.Input;
        var velocity = new Vector3(input.x, 0, input.y) * _speed * Time.deltaTime;

        _balloonRigidbody.angularVelocity = Vector3.zero;
        _balloonRigidbody.velocity = velocity;
    }

    private void LateUpdate()
    {
        var pos = _balloonTransform.position;
        _balloonTransform.position = new Vector3(pos.x, _initialPosition.y, pos.z);
    }
}
