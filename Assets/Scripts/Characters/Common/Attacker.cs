using UnityEngine;

public class Attacker : IAttacker
{
    private readonly IAttackSetting _attackSetting;
    private readonly SpriteRenderer _sprite;
    private readonly Transform _transform;

    public Attacker (IAttackSetting attackSetting, SpriteRenderer sprite, Transform transform)
    {
        _attackSetting = attackSetting;
        _sprite = sprite;
        _transform = transform;
    }

    public void Attack()
    {
        Vector2 attackDirection = _sprite.flipX ? Vector2.left : Vector2.right;

        Debug.Log($"AttackRange = {_attackSetting.AttackRange}, EnemyLayerMask = {_attackSetting.EnemyLayerMask}");

        RaycastHit2D hit = new RaycastHit2D();

        if (hit.collider != null)
            if (hit.collider.TryGetComponent(out IDamageable enemy) == true)
                enemy?.TakeDamage(_attackSetting.AttackDamage);

        Debug.DrawRay(_transform.position, attackDirection * _attackSetting.AttackRange, Color.red, _attackSetting.AttackRange);
    }
}