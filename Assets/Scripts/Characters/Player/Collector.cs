using System;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public event Action<Coin> CoinCollected;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Coin>(out Coin coin))
        {
            CoinCollected?.Invoke(coin);
        }
    }
}