using UnityEngine;

public class Jumper : IJumper
{
    private readonly Rigidbody2D _rigidbody;

    public Jumper(Rigidbody2D rigidbody, IJumpSetting setting)
    {
        _rigidbody = rigidbody;
        Setting = setting;
    }

    public IJumpSetting Setting { get; private set; }

    public Vector2 Velocity => _rigidbody.linearVelocity;

    public void Jump()
    {
        _rigidbody.AddForce(new Vector2(0, Setting.JumpForce), ForceMode2D.Impulse);
    }
}