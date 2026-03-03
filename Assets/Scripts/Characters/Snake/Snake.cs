using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeAnimator _animator;
    [SerializeField] private SnakeSetting _snakeSetting;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Health _health;
    [SerializeField] private SnakeAI _snakeAI;

    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }

    public SnakeAnimator Animator => _animator;
    public SnakeSetting SnakeSetting => _snakeSetting;
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public Health Health => _health;
    public SnakeAI SnakeAI => _snakeAI;


    private void Update()
    {
    }
}