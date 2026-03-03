using UnityEngine;
using UnityEngine.InputSystem;

public class Flipper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    public void OnMove(InputValue value)
    {
        float direction = value.Get<float>();

        if (direction == 1 && _sprite.flipX == true)
            _sprite.flipX = false;
        else if (direction == -1 && _sprite.flipX == false)
            _sprite.flipX = true;
    }
}