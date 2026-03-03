using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    private float _moveDirectionX;

    public event Action JumpPressed;
    public event Action AttackPressed;

    private Flipper _flipper;

    public float MoveDirectionX => _moveDirectionX;

    public void OnMove(InputValue value)
    {
        _moveDirectionX = value.Get<float>();
    }

    public void OnJump(InputValue value)
    {
        JumpPressed?.Invoke();
    }

    public void OnAttack()
    {
        AttackPressed?.Invoke();
    }
}