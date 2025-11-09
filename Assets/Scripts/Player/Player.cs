using UnityEngine;

[RequireComponent(typeof(PlayerStateMachine), typeof(PlayerAnimator), typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _healthRecoveryAmount = 20f;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Collector _collector;
    [SerializeField] private LayerMask _enemyLayerMask;

    private int _coins = 0;

    private Health _health;
    private InputReader _userInput;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _userInput = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _collector.RaisedCoin += AddCoin;
        _userInput.Attacking += Attack;
        _collector.RaisedFirstAidKit += RecoverHealth;
    }

    private void OnDisable()
    {
        _collector.RaisedCoin -= AddCoin;
        _userInput.Attacking -= Attack;
        _collector.RaisedFirstAidKit -= RecoverHealth;
    }

    private void Attack()
    {
        Vector2 attackDirection;

        if (transform.rotation.y >= 0)
            attackDirection = Vector2.right;
        else
            attackDirection = Vector2.left;

        RaycastHit2D hit = Physics2D.Raycast(_attackPoint.position, attackDirection, _attackRange, _enemyLayerMask );

        if (hit.collider != null)
        {
            Health enemyHealth;

            if (hit.collider.TryGetComponent(out enemyHealth))
                if (enemyHealth != null)
                    enemyHealth.TakeDamage(_damage);
        }
    }

    private void RecoverHealth()
    {
        _health.Heal(_healthRecoveryAmount);
    }

    private void AddCoin() =>
       _coins++;
}