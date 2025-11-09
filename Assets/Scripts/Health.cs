using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Range(0, 100)][SerializeField] private float _health = 100f;
    [SerializeField] private float _maxHealth = 100f;

    public event Action Died;
    public event Action HitReceived;

    public void TakeDamage(float damage)
    {
        if (damage >= _health)
            _health -= _health;

        if (damage < 0)
            damage = 0;

        _health -= damage;

        HitReceived?.Invoke();

        if (_health < 0)
            _health = 0;

        if (_health == 0)
            Died?.Invoke();
    }

    public void Heal(float healAmount)
    {
        if (healAmount < 0)
            healAmount = 0;

        _health += healAmount;

        if (_health > _maxHealth)
            _health = _maxHealth;
    }
}