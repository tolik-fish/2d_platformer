using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _raycastDistance;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void Update()
    {
        _isGrounded = TryFindGround();
    }

    private bool TryFindGround()
    {
        Vector2 position = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, -_raycastDistance, _layerMask);

        if (hit.collider != null)
            return true;
        else
            return false;
    }
}