using UnityEngine;

public class SnakeSetting : ISnakeSetting
{
    [field:SerializeField] public float MoveSpeed { get; private set; }

    [field: SerializeField] public float MaxSpeed { get; private set; }

    [field: SerializeField] public float MaxHealthValue { get; private set; }

    [field: SerializeField] public float AttackDamage { get; private set; }

    [field: SerializeField] public float AttackRange { get; private set; }

    [field: SerializeField] public float AttackSpeed { get; private set; }

    [field: SerializeField] public LayerMask EnemyLayerMask { get; private set; }
}