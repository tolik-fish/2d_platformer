using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth
{
    public event Action Died;

    public Health(float value, IHealthSetting healthSetting)
    {
        Value = value;
        Setting = healthSetting;
    }

    public float Value {  get; private set; }

    public IHealthSetting Setting { get; private set; }

    public void TakeDamage(float damage)
    {
        if (damage >= Value)
            Value -= Value;

        if (damage < 0)
            damage = 0;

        Value -= damage;

        if (Value < 0)
            Value = 0;

        if (Value == 0)
            Died?.Invoke();
    }

    public void Heal(float healAmount)
    {
        if (healAmount < 0)
            healAmount = 0;

        Value += healAmount;

        if (Value > Setting.MaxHealthValue)
            Value = Setting.MaxHealthValue;
    }
}