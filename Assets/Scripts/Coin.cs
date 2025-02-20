using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Player _player;

    public event Action Raised;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Player player;

        if (collider.TryGetComponent<Player>(out player))
        {
            player.AddCoin();

            Destroy(gameObject);
        }
    }
}