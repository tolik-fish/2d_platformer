using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _transform;

    private void Update()
    {
        Vector2 Direction = _transform.position;

        _camera.transform.position = Direction;
        Debug.Log(Equals(Direction));
    }
}