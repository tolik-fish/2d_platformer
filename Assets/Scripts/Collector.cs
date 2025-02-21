using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collector : MonoBehaviour
{
    public event Action Raised;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            Raised?.Invoke();

            Destroy(coin.gameObject);
        }
    }
}