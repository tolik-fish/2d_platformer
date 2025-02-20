using UnityEngine;

[RequireComponent(typeof(PlayerStateManager), typeof(AnimationControl))]
public class Player : MonoBehaviour
{
    private int _coins = 0;

    public void AddCoin() =>
        _coins++;
}