using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const KeyCode CodeKey = KeyCode.Space;

    public event Action Standing;
    public event Action Jumping;
    public event Action<float> Running;

    private void Update()
    {
            Move();

            Leap();
    }

    private void Move()
    {
        float direction = Input.GetAxis(Horizontal);

        if (direction != 0)
            Running?.Invoke(direction);
        else
            Standing?.Invoke();
    }

    private void Leap()
    {
        if (Input.GetKeyDown(CodeKey))
            Jumping?.Invoke();
    }
}