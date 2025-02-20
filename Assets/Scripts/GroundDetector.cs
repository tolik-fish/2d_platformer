using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private const string LayerName = "Ground";

    [SerializeField] private float _RaycastDistance;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void Update()
    {
        _isGrounded = SetBool();
    }

    private bool SetBool()
    {
        Vector2 position = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, -_RaycastDistance, LayerMask.GetMask(LayerName));

        if (hit.collider != null)
            return true;
        else
            return false;
    }
}