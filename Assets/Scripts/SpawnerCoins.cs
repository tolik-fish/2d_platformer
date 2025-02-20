using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private List<Transform> _points;

    private void Start()
    {
        foreach (Transform point in _points)
            CreateCoin(point);
    }

    private void CreateCoin(Transform point)
    {
        Coin coin = Coin.Instantiate(_prefab);

        coin.transform.position = point.position;
    }
}