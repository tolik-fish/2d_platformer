using UnityEngine;

public static class AnimationsData
{
    public static class HeroAnimations
    {
        public static readonly int IdleParameter = Animator.StringToHash("Idle");
        public static readonly int MoveParameter = Animator.StringToHash("Move");
        public static readonly int AttackParameter = Animator.StringToHash("Attack");
        public static readonly int JumpParameter = Animator.StringToHash("Jump");
    }

    public static class SnakeAnimations
    {
        public static readonly int IdleParameter = Animator.StringToHash("Idle");
        public static readonly int MoveParameter = Animator.StringToHash("Move");
        public static readonly int AttackParameter = Animator.StringToHash("Attack");
    }
}