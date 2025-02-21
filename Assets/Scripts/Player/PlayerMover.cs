using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private float _jumpForce;

    private InputReader _input;

    private void Awake()
    {
        _input = GetComponent<InputReader>();
        Rigibody = GetComponent<Rigidbody2D>();
        GroundDetector = GetComponent<GroundDetector>();
    }

    private void OnEnable()
    {
        _input.Running += Move;
        _input.Jumping += Jump;
    }

    private void OnDisable()
    {
        _input.Running -= Move;
        _input.Jumping -= Jump;
    }

    public void Jump()
    {
        if (GroundDetector.IsGrounded)
            Rigibody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }
}