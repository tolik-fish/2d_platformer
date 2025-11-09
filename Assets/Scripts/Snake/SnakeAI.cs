using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Snake), typeof(DelayControl))]
public class SnakeAI : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private List<Transform> _points;

    private float _directionX;
    private float _threshold = 0.1f;
    private int _pointIndex;
    private bool _iFindPlayer = false;
    private bool _iChasing = false;
    private bool _isCooldownOver = true;

    private Coroutine _detectPlayerCoroutine;
    private Coroutine _attackCoroutine;
    private DelayControl _delayTimeChaseControl;
    private DelayControl _delayTimeAttackControl;
    private Snake _snake;

    private void Awake()
    {
        _snake = GetComponent<Snake>();
        _delayTimeChaseControl = GetComponent<DelayControl>();
        _delayTimeAttackControl = GetComponent<DelayControl>();
    }

    private void OnEnable()
    {
        _delayTimeChaseControl.TimeIsOver += SetTrueStatusHarassment;
        _delayTimeAttackControl.TimeIsOver += SetTrueStatusCooldown;
    }

    private void OnDisable()
    {
        _delayTimeChaseControl.TimeIsOver -= SetTrueStatusHarassment;
        _delayTimeAttackControl.TimeIsOver -= SetTrueStatusCooldown;
    }

    private void Start()
    {
        _pointIndex = 0;

        GetDirection(_points[_pointIndex].position.x, transform.position.x);
    }

    private void Update()
    {
        bool iFind = TryFindPlayer();

        if (iFind && _iFindPlayer == false)
        {
            float detectionTime = _snake.GetDetectionTime();

            _detectPlayerCoroutine = StartCoroutine(_delayTimeChaseControl.WaitTime(detectionTime));

            _iFindPlayer = true;
        }
        else if (iFind == false && _iFindPlayer == false)
        {
            Patrol();
        }
        else if (_iFindPlayer == true && iFind == false)
        {
            if (_detectPlayerCoroutine != null)
                StopCoroutine(_detectPlayerCoroutine);

            _iFindPlayer = false;
        }

        if (_iChasing)
        {
            Chase();

            if (_isCooldownOver)
            {
                _snake.Attack();

                if (_attackCoroutine != null)
                    StopCoroutine(_attackCoroutine);

                StartCooldown();

                _isCooldownOver = false;
            }
        }
    }

    private void Patrol()
    {
        _directionX = GetDirection(_points[_pointIndex].position.x, transform.position.x);

        if (IsReachPoint())
        {
            _pointIndex = GetNextIndex();

            GetDirection(_points[_pointIndex].position.x, transform.position.x);
        }

        _snake.Move(_directionX);
    }


    private void Chase()
    {
        float distanceToPlayer = Vector2.Distance(_playerTransform.position, transform.position);
        float attackDistance = _snake.GetAttackDistance();

        if (distanceToPlayer > attackDistance)
        {
            float direction = GetDirection(_playerTransform.position.x, transform.position.x);

            _snake.Move(direction);
        }
        else if (_isCooldownOver == false)
        {
            _snake.Stand();
        }

        if (_detectPlayerCoroutine != null)
            StopCoroutine(_detectPlayerCoroutine);

    }

    private float GetDirection(float positionOne, float positionTwo)
    {
        float max = 1f;
        float min = -1f;

        return Mathf.Clamp(positionOne - positionTwo, min, max);
    }

    private bool TryFindPlayer()
    {
        float viewDistance = _snake.GetViewDistance();
        float distanceToPlayer = Vector2.Distance(_playerTransform.position, transform.position);
        float playerPositionRelativeSnake = _playerTransform.position.x - transform.position.x;
        bool isPlayerOnRightSide = playerPositionRelativeSnake > 0;

        if (distanceToPlayer <= viewDistance)
        {
            if ((isPlayerOnRightSide && _snake.IsLookDirectRightSide) || (!isPlayerOnRightSide && !_snake.IsLookDirectRightSide))
                return true;
            else
                return false;
        }
        else
            return false;
    }

    private void StartCooldown()
    {
        float attackCooldownTime = _snake.GetAttackCooldown();

        _attackCoroutine = StartCoroutine(_delayTimeAttackControl.WaitTime(attackCooldownTime));
    }

    private bool IsReachPoint() =>
        Mathf.Abs(transform.position.x - _points[_pointIndex].position.x) < _threshold;

    private void SetTrueStatusHarassment() =>
        _iChasing = true;

    private void SetTrueStatusCooldown() =>
        _isCooldownOver = true;

    private int GetNextIndex() =>
         ++_pointIndex % _points.Count;
}