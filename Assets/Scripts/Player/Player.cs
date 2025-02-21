using UnityEngine;

[RequireComponent(typeof(PlayerStateMachine), typeof(PlayerAnimator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Collector _collector;

    private int _coins = 0;

    private void OnEnable()
    {
        _collector.Raised += AddCoin;
    }

    private void OnDisable()
    {
        _collector.Raised -= AddCoin;
    }

    private void AddCoin() =>
       _coins++;
}