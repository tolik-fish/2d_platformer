using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundDetector))]
public abstract class Mover : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected Rigidbody2D Rigibody;
    protected GroundDetector GroundDetector;

    private void Awake()
    {
        Rigibody = GetComponent<Rigidbody2D>();
        GroundDetector = GetComponent<GroundDetector>();
    }

    public void Move(float value)
    {
        Vector2 velocity = Rigibody.velocity;
        velocity.x = value * Speed;
        Rigibody.velocity = velocity;
    }
}