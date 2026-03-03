using System;

public interface IHealth : IDamageable
{ 
    float Value { get; }

    event Action Died;

    IHealthSetting Setting { get; }
}