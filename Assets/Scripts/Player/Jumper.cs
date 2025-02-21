using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private GroundDetector _groundDetector;
    private Rigidbody2D _rigidbody;
    private InputReader _input;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _input.Jumping += Jump;
    }

    private void OnDisable()
    {
        _input.Jumping -= Jump;
    }

    public void Jump()
    {
        if (_groundDetector.IsGrounded)
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}