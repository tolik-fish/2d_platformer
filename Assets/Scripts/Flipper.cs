using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _minRotation = 0;
    private float _maxRotation = 180f;

    public void TurnAround(float value)
    {
        if (value < 0)
            transform.rotation = Quaternion.Euler(new Vector2(0f, _maxRotation));
        else
            transform.rotation = Quaternion.Euler(new Vector2(0f, _minRotation));
    }
}