using UnityEngine;

public class PlayerMover : Mover
{
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
    }

    private void OnDisable()
    {
        _input.Running -= Move;
    }
}