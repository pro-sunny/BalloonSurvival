using System.Collections;
using UnityEngine;
using Zenject;

public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject _balloon;
    [SerializeField] private Collider _balloonCollider;
    [SerializeField] private GameObject _deathVFX;

    [SerializeField] private float _radius;
    [SerializeField] private float _power;

    private GameStateMachine _stateMachine;

    [Inject]
    private void Construct(GameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out var enemy))
        {
            _deathVFX.SetActive(true);

            var pos = transform.position;
            Collider[] newColliders = Physics.OverlapSphere(pos, _radius);
            foreach (var collider in newColliders)
            {
                if (collider.TryGetComponent<ChasingEnemy>(out var chasingEnemy) &&  collider.TryGetComponent<Rigidbody>(out var enemyRigidbody))
                {
                    enemyRigidbody.AddExplosionForce(_power, pos, _radius, 0, ForceMode.Impulse);
                }
            }

            Destroy(_balloon);
            _balloonCollider.enabled = false;
            
            var vfx = Instantiate(_deathVFX, pos, Quaternion.identity);
            Destroy(vfx, 2);

            _stateMachine.Enter<GameOverState>();
        }
    }
}