using UnityEngine;

public interface IAttackSetting
{
    float AttackDamage { get; }

    float AttackRange { get; }

    float AttackSpeed { get; }

    LayerMask EnemyLayerMask { get; }
}