using UnityEngine;

public class HeroAnimator : MonoBehaviour, IHeroAnimator
{
    [SerializeField] private Animator _animator;

    public void PlayIdle() =>
        PlayAnimation(AnimationsData.HeroAnimations.IdleParameter);
    public void PlayMove() =>
        PlayAnimation(AnimationsData.HeroAnimations.MoveParameter);

    public void PlayAttack() =>
        PlayAnimation(AnimationsData.HeroAnimations.AttackParameter);

    public void PlayJump() =>
        PlayAnimation(AnimationsData.HeroAnimations.JumpParameter);

    private void PlayAnimation(int id) =>
        _animator.SetTrigger(id);
}