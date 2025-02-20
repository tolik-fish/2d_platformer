using UnityEngine;

public class PlayerAnimator : AnimationControl
{
    protected const int FallNumber = 2;

    private PlayerStateManager _stateManager;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        _stateManager = GetComponent<PlayerStateManager>();
    }

    private void OnEnable()
    {
        _stateManager.Running += PlayRun;
        _stateManager.Standing += PlayStand;
        _stateManager.Falling += PlayFall;
    }

    private void OnDisable()
    {
        _stateManager.Running -= PlayRun;
        _stateManager.Standing -= PlayStand;
        _stateManager.Falling -= PlayFall;
    }

    private void PlayFall()
    {
        Animator.SetInteger(StateName, FallNumber);
    }
}
