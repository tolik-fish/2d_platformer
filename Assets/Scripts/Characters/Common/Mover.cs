using UnityEngine;

public class Mover : IMover
{
    private readonly Rigidbody2D _rigidbody;

    public Mover(Rigidbody2D rigidbody, IMoveSetting setting)
    {
        _rigidbody = rigidbody;
        Setting = setting;
    }

    public IMoveSetting Setting { get; private set; }

    public void Move(float direction)
    {
        float velocity = _rigidbody.linearVelocityX;

        velocity += direction * Setting.MoveSpeed;

        if(velocity >Setting.MaxSpeed)
            velocity = Setting.MaxSpeed;
        else if(velocity < -Setting.MaxSpeed)
            velocity = -Setting.MaxSpeed;

        _rigidbody.linearVelocityX = velocity;
    }
}