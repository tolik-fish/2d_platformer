using UnityEngine;

public class SnakeAnimator : AnimationControl
{
    private SnakeStateManager _stateManager;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        _stateManager = GetComponent<SnakeStateManager>();
    }

    private void OnEnable()
    {
        _stateManager.Running += PlayRun;
        _stateManager.Standing += PlayStand;
    }

    private void OnDisable()
    {
        _stateManager.Running -= PlayRun;
        _stateManager.Standing -= PlayStand;
    }
}