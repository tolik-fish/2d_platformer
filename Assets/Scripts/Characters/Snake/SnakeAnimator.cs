using UnityEngine;

public class SnakeAnimator : MonoBehaviour ,ISnakeAnimator
{
    [SerializeField] private Animator _animator;

    public void PlayAttack()
    {
        _animator.SetTrigger(AnimationsData.SnakeAnimations.AttackParameter);
    }

    public void PlayIdle()
    {
        _animator.SetTrigger(AnimationsData.SnakeAnimations.IdleParameter);
    }

    public void PlayMove()
    {
        _animator.SetTrigger(AnimationsData.SnakeAnimations.MoveParameter);
    }
}