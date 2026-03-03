using UnityEngine;

public interface IJumper
{
    Vector2 Velocity { get; }

    IJumpSetting Setting { get; }

    void Jump();
}