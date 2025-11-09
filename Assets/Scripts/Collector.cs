using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collector : MonoBehaviour
{
    public event Action RaisedCoin;
    public event Action RaisedFirstAidKit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Coin>(out Coin coin))
        {
            RaisedCoin?.Invoke();

            Destroy(coin.gameObject);
        }
        else if (collider.TryGetComponent<FirstAidKit>(out FirstAidKit firstAidKit))
        {
            RaisedFirstAidKit?.Invoke();

            Destroy(firstAidKit.gameObject);
        }
    }
}