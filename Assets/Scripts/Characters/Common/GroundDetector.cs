using UnityEngine;

public class GroundDetector : MonoBehaviour, IGroundDetector
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _raycastDistance;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        IsGrounded = TryFindGround();
    }

    public bool TryFindGround()
    {
        Vector2 position = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, _raycastDistance, _layerMask);

        if (hit.collider != null)
            return true;
        else
            return false;
    }
}