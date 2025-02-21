using UnityEngine;

public class PlayerAnimator : AnimationPlayer
{
    private const int FallNumber = 2;

    public void PlayFall()
    {
        Animator.SetInteger(StateName, FallNumber);
    }
}