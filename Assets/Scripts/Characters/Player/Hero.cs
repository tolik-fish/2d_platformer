using UnityEngine;

[RequireComponent(typeof(HeroAnimator), typeof(Health))]
public class Hero : MonoBehaviour, IDamageable, IDestroyable
{
    [SerializeField] private HeroAnimator _Animator;
    [SerializeField] private PlayerSetting _setting;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private Health _health;
    [SerializeField] private PlayerControls _playerInput;
    [SerializeField] private SpriteRenderer _sprite;

    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }

    private IStateMachineUpdater _stateMachineUpdater;

    public HeroAnimator Animator => _Animator;
    public PlayerSetting Setting => _setting;
    public GroundDetector GroundDetector => _groundDetector;
    public Health Health => _health;
    public PlayerControls PlayerInput => _playerInput;
    public SpriteRenderer Sprite => _sprite;

    private void OnEnable()
    {
        _health.Died += Destroy;
    }

    private void OnDisable()
    {
        _health.Died -= Destroy;
    }

    private void FixedUpdate()
    {
        _stateMachineUpdater.FixedUpdateState(Time.deltaTime);
    }

    private void Update()
    {
        _stateMachineUpdater.UpdateState(Time.deltaTime);
    }

    public void Construct(IStateMachineUpdater stateMachineUpdater)
    {
        _stateMachineUpdater = stateMachineUpdater;
    }

    public void Destroy() =>
        Destroy(gameObject);

    public void TakeDamage(float damageAmount) =>
        _health.TakeDamage(damageAmount);
}